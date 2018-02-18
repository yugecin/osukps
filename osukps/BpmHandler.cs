using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace osukps {
	class BpmHandler {

		private long[] times;
		private int idx;
		private Stopwatch timer;
		private Label lbl;
		public int divider;
		public int measure;
		
		public BpmHandler(Label lbl) {
			times = new long[11];
			timer = Stopwatch.StartNew();
			divider = 4;
			measure = 5;
			this.lbl = lbl;
		}

		public void OnKeypress() {
			idx = ++idx % times.Length;
			times[idx] = timer.ElapsedMilliseconds;
			int previdx = idx - measure;
			if (previdx < 0) {
			     previdx += times.Length;
			}
			long d = times[idx] - times[previdx];
			if (d == 0L) {
				return;
			}
			int bpm = measure * (int) (60000L / d) / divider;
			lbl.Text = bpm + " bpm";
		}

	}
}
