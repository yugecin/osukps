using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	class KpsHandler {

		private Label lblKps;
		private Label lblTotal;
		private byte index;
		private byte[] kps;
		public int total { get; private set; }
		public int max { get; private set; }

		public KpsHandler(Label lblKps, Label lblTotal) {
			this.lblKps = lblKps;
			this.lblTotal = lblTotal;
			kps = new byte[10];
			Timer timer = new Timer();
			timer.Interval = 100;
			timer.Tick += t_Tick;
			timer.Start();
		}

		private void t_Tick(object sender, System.EventArgs e) {
			kps[index] = 0;
			if (++index >= 10) {
				index = 0;
			}
		}

		public void Update(byte keyCount) {
			for (byte i = 0; i < 10; i++) {
				kps[i] += keyCount;
			}
			total += keyCount;
			UpdateLabels();
		}

		private void UpdateLabels() {
			byte kps = this.kps[index];
			if (kps > max) {
				max = kps;
			}

			bool smoothen = false;
			Color nextcol = Color.White;
			Color prevcol = nextcol;
			int nextkps = 0;
			float progress = 0;
			int i = frmMain.kpscolorscount;
			if (i > 0) {
				KPSCOLOR kc = frmMain.kpscolors[i - 1];
				nextcol = kc.color;
				nextkps = kc.kps;
			}
			while (--i >= 0) {
				KPSCOLOR kc = frmMain.kpscolors[i];
				if (kps >= kc.kps) {
					prevcol = kc.color;
					if (kps != 0) {
						progress = (kps - kc.kps) / (float) (nextkps - kc.kps);
					}
					break;
				}
				nextcol = kc.color;
				nextkps = kc.kps;
				smoothen = kc.smoothen;
				if (i == 0) {
					prevcol = Color.White;
					progress = kps / (float) (nextkps);
				}
			}
			if (smoothen) {
				prevcol = Color.FromArgb(
					255,
					prevcol.R + (int) ((nextcol.R - prevcol.R) * progress),
					prevcol.G + (int) ((nextcol.G - prevcol.G) * progress),
					prevcol.B + (int) ((nextcol.B - prevcol.B) * progress)
				);
			}
			lblKps.ForeColor = prevcol;

			if (kps == 0) {
				lblKps.Text = string.Format("{0} Max", max);
			} else lblKps.Text = string.Format("{0} Kps", kps);

			lblTotal.Text = total.ToString();
		}

		public void SetTotal(int total) {
			this.total = total;
			UpdateLabels();
		}

		public void SetMax(int max) {
			this.max = max;
			UpdateLabels();
		}

	}
}
