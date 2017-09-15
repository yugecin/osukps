using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace osukps {
	partial class frmMain {

		private const uint RS_NONE = 0;
		private const uint RS_RECORDING = 1;
		private const uint RS_PLAYBACK = 2;
		private const int TIMER_INTERVAL = 2;
		private const int REC_TIMESTEP_BITS = 32 - MAX_BUTTONS;
		private const uint TIMEMASK = 0xffffffff >> MAX_BUTTONS;
		private const uint EVENTMASK = ~TIMEMASK;
		private static readonly RecordingData recordingstart = new RecordingData();
		private static RecordingData crs = recordingstart;
		private KPSDATA infobeforerecord;
		private KPSDATA infoafterrecord;
		private IKeyHandler[] savedkeyhandlers = new IKeyHandler[MAX_BUTTONS];
		private uint currentsegmenttime;
		class RecordingData {
			public uint[] data = new uint[1022];
			public int idx = 1;
			public RecordingData next;
		}
		struct KPSDATA {
			public int total;
			public int max;
		}

		private void UpdatePlayback() {
			currentsegmenttime++;
			if (currentsegmenttime < (crs.data[crs.idx] & TIMEMASK)) {
				return;
			}
			currentsegmenttime = 0;
			crs.idx++;
			if (crs.idx < crs.data.Length) {
				if (crs.data[crs.idx] == 0) {
					StopPlayback();
				}
				return;
			}
			crs = crs.next;
			crs.idx = 0;
			if (crs == null) {
				StopPlayback();
			}
		}

		private void UpdateRecord(uint eventmask) {
			switch (recordingstate) {
			case RS_RECORDING: break;
			case RS_PLAYBACK: UpdatePlayback(); return;
			default: return;
			}

			eventmask <<= REC_TIMESTEP_BITS;
			EnsureRecordingCapacity(copyevent: true);
			if ((crs.data[crs.idx-1] & EVENTMASK) == eventmask) {
				crs.data[crs.idx-1]++;
				return;
			}
			crs.idx++;
			if (crs.idx > crs.data.Length) {
				crs.next = new RecordingData();
				crs.idx = 1;
				crs = crs.next;
			}
			EnsureRecordingCapacity(copyevent: false);
			crs.data[crs.idx-1] = eventmask + 1;
		}

		private void EnsureRecordingCapacity(bool copyevent) {
			uint t = crs.data[crs.idx-1];
			if ((t & TIMEMASK) != TIMEMASK) {
				return;
			}
			if (crs.idx < crs.data.Length) {
				crs.idx++;
				if (copyevent) {
					crs.data[crs.idx-1] = t & EVENTMASK;
				}
				return;
			}
			crs.idx = 1;
			crs.next = new RecordingData();
			crs = crs.next;
			if (copyevent) {
				crs.data[0] = t & EVENTMASK;
			}
		}

		private void StartRecording() {
			if (recordingstate == RS_PLAYBACK) {
				StopPlayback();
			}
			infobeforerecord.total = kpsHandler.total;
			infobeforerecord.max = kpsHandler.max;
			recordingstate = RS_RECORDING;
			cmsStartStopRecording.Text = "Stop recording";
			crs = recordingstart;
			crs.next = null;
			crs.idx = 1;
			Array.Clear(crs.data, 0, crs.data.Length);
			crs.data[0] = 1;
			pnlInfo.BackColor = pnlKeys.BackColor = Color.Maroon;
		}

		private void StopRecording() {
			recordingstate = RS_NONE;
			cmsStartStopRecording.Text = "Start recording";
			pnlInfo.BackColor = pnlKeys.BackColor = Color.Black;
		}

		private void StartPlayback() {
			if (recordingstate == RS_RECORDING) {
				StopRecording();
			}
			infoafterrecord.total = kpsHandler.total;
			infoafterrecord.max = kpsHandler.max;
			kpsHandler.SetMax(infobeforerecord.max);
			kpsHandler.SetTotal(infobeforerecord.total);
			uint keymask = 0x80000000;
			for (int i = 0; i < MAX_BUTTONS; i++) {
				savedkeyhandlers[i] = btns[i].keyhandler;
				btns[i].keyhandler = new PlaybackKeyHandler(keymask);
				keymask >>= 1;
			}
			currentsegmenttime = 0;
			crs = recordingstart;
			crs.idx = 0;
			recordingstate = RS_PLAYBACK;
			cmsPlaybackRecording.Text = "Stop playbacking";
		}

		private void StopPlayback() {
			kpsHandler.SetMax(infoafterrecord.max);
			kpsHandler.SetTotal(infoafterrecord.total);
			for (int i = 0; i < MAX_BUTTONS; i++) {
				btns[i].keyhandler = savedkeyhandlers[i];
			}
			recordingstate = RS_NONE;
			cmsPlaybackRecording.Text = "Playback recording";
		}

		private class PlaybackKeyHandler : IKeyHandler {
			private uint keymask;
			public PlaybackKeyHandler(uint keymask) {
				this.keymask = keymask;
			}
			public byte Handle() {
				if ((crs.data[crs.idx] & keymask) > 0)  {
					return 1;
				}
				return 0;
			}
		}

	}
}
