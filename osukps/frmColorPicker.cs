using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	public partial class frmColorPicker : Form {

		private static frmColorPicker instance = new frmColorPicker();

		private Color color;
		private bool cancelled;

		public frmColorPicker() {
			InitializeComponent();
		}

		public static Color? ShowAndEdit(Color color) {
			instance.color = color;
			instance.ShowDialog();
			if (instance.cancelled) {
				return null;
			}
			return instance.color;
		}

		private void frmColorPicker_Load(object sender, EventArgs e) {
			cancelled = true;
			rscroll.Value = color.R;
			gscroll.Value = color.G;
			bscroll.Value = color.B;
			Updatevalues(true);
			DialogPositioner.ApplyTo(this);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e) {
			cancelled = false;
			Close();
		}

		private void Updatevalues(bool updateHexText) {
			color = Color.FromArgb(255, rscroll.Value, gscroll.Value, bscroll.Value);
			rnum.Value = rscroll.Value;
			gnum.Value = gscroll.Value;
			bnum.Value = bscroll.Value;
			if (updateHexText) {
				txtHex.Text = string.Format("{0:x6}", color.ToArgb() & 0xFFFFFF);
			}
			preview.BackColor = color;
		}

		private void rscroll_Scroll(object sender, ScrollEventArgs e) {
			Updatevalues(true);
		}

		private void gscroll_Scroll(object sender, ScrollEventArgs e) {
			Updatevalues(true);
		}

		private void bscroll_Scroll(object sender, ScrollEventArgs e) {
			Updatevalues(true);
		}

		private void rnum_ValueChanged(object sender, EventArgs e) {
			rscroll.Value = (int) rnum.Value;
			Updatevalues(true);
		}

		private void gnum_ValueChanged(object sender, EventArgs e) {
			gscroll.Value = (int) gnum.Value;
			Updatevalues(true);
		}

		private void bnum_ValueChanged(object sender, EventArgs e) {
			bscroll.Value = (int) bnum.Value;
			Updatevalues(true);
		}

		private void txtHex_TextChanged(object sender, EventArgs e) {
			string t = txtHex.Text;

			if (t.Length != 6) {
				return;
			}

			foreach (char c in t.ToCharArray()) {
				if ('0' <= c && c <= '9') {
					continue;
				}
				char d = (char) (c | 0x20);
				if ('a' <= d && d <= 'f') {
					continue;
				}
			}

			rscroll.Value = Convert.ToByte(t.Substring(0, 2), 16);
			gscroll.Value = Convert.ToByte(t.Substring(2, 2), 16);
			bscroll.Value = Convert.ToByte(t.Substring(4, 2), 16);

			Updatevalues(false);
		}

	}
}
