using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace osukps {
	partial class frmMain {

		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(int vkey);

		private const uint RS_NONE = 0;
		private const uint RS_RECORDING = 1;
		private const uint RS_PLAYBACK = 2;
		private static readonly RecordingData recordingstart = new RecordingData();
		private static RecordingData crs = recordingstart;
		private KPSDATA infobeforerecord;
		private KPSDATA infoafterrecord;
		private IKeyHandler[] savedkeyhandlers = new IKeyHandler[MAX_BUTTONS];
		private Stopwatch timer = new Stopwatch();
		class RecordingData {
			public uint mask;
			public long endtime;
			public RecordingData next;
		}
		struct KPSDATA {
			public int total;
			public int max;
		}

		private void UpdatePlayback() {
			if (timer.ElapsedMilliseconds >= crs.endtime) {
				crs = crs.next;
				if (crs == null) {
					StopPlayback();
					crs = recordingstart;
					return;
				}
			}
		}

		private bool keystate;
		private void UpdateRecord(uint eventmask) {
			if (reckey != 0 && ((GetAsyncKeyState(reckey) & 0x8000) == 0x8000)) {
				if (!keystate) {
					keystate = true;
					if (recordingstate == RS_RECORDING) {
						StopRecording();
						return;
					}
					StartRecording();
				}
			} else {
				keystate = false;
			}

			switch (recordingstate) {
			case RS_RECORDING: break;
			case RS_PLAYBACK: UpdatePlayback(); return;
			default: return;
			}

			if (crs.mask == eventmask) {
				return;
			}
			crs.endtime = timer.ElapsedMilliseconds;
			crs.next = new RecordingData();
			crs = crs.next;
			crs.mask = eventmask;
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
			timer.Reset();
			timer.Start();
			pnlInfo.BackColor = pnlKeys.BackColor = Color.Maroon;
		}

		private void StopRecording() {
			recordingstate = RS_NONE;
			cmsStartStopRecording.Text = "Start recording";
			pnlInfo.BackColor = pnlKeys.BackColor = Color.Black;
			crs.endtime = timer.ElapsedMilliseconds;
			timer.Reset();
		}

		private void StartPlayback() {
			if (recordingstate == RS_RECORDING) {
				StopRecording();
			}
			infoafterrecord.total = kpsHandler.total;
			infoafterrecord.max = kpsHandler.max;
			kpsHandler.SetMax(infobeforerecord.max);
			kpsHandler.SetTotal(infobeforerecord.total);
			uint keymask = 1;
			for (int i = MAX_BUTTONS; i > 0;) {
				savedkeyhandlers[--i] = btns[i].keyhandler;
				btns[i].keyhandler = new PlaybackKeyHandler(keymask);
				keymask <<= 1;
			}
			crs = recordingstart;
			timer.Reset();
			timer.Start();
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
			timer.Reset();
		}

		private class PlaybackKeyHandler : IKeyHandler {
			private uint keymask;
			public PlaybackKeyHandler(uint keymask) {
				this.keymask = keymask;
			}
			public byte Handle() {
				if ((crs.mask & keymask) > 0)  {
					return 1;
				}
				return 0;
			}
		}

	}
}
