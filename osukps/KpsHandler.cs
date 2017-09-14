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
			if (kps >= 10) {
				lblKps.ForeColor = Color.FromArgb(255, 248, 0, 0);
			} else if (kps >= 5) {
				lblKps.ForeColor = Color.FromArgb(255, 0, 190, 255);
			} else {
				lblKps.ForeColor = Color.White;
			}

			if (kps == 0) {
				lblKps.Text = string.Format("{0} Max", max);
			} else lblKps.Text = string.Format("{0} Kps", kps);

			lblTotal.Text = total.ToString();

			//frmMain.kpsmax(kps);
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
