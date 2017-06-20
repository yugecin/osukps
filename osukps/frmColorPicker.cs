using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
			updatevalues();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e) {
			cancelled = false;
			Close();
		}

		private void updatevalues() {
			color = Color.FromArgb(255, rscroll.Value, gscroll.Value, bscroll.Value);
			rnum.Value = rscroll.Value;
			gnum.Value = gscroll.Value;
			bnum.Value = bscroll.Value;
			preview.BackColor = color;
		}

		private void rscroll_Scroll(object sender, ScrollEventArgs e) {
			updatevalues();
		}

		private void gscroll_Scroll(object sender, ScrollEventArgs e) {
			updatevalues();
		}

		private void bscroll_Scroll(object sender, ScrollEventArgs e) {
			updatevalues();
		}

		private void rnum_ValueChanged(object sender, EventArgs e) {
			rscroll.Value = (int) rnum.Value;
			updatevalues();
		}

		private void gnum_ValueChanged(object sender, EventArgs e) {
			gscroll.Value = (int) gnum.Value;
			updatevalues();
		}

		private void bnum_ValueChanged(object sender, EventArgs e) {
			bscroll.Value = (int) bnum.Value;
			updatevalues();
		}
	}
}
