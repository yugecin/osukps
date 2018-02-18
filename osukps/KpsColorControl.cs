using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace osukps {
	public partial class KpsColorControl : UserControl, IComparable<KpsColorControl> {

		public event EventHandler OnRemove;

		public KpsColorControl() {
			InitializeComponent();
		}

		public void Use(KPSCOLOR kpscolor) {
			this.btnColor.BackColor = kpscolor.color;
			this.nudKps.Value = kpscolor.kps;
			this.chkSmoothColor.Checked = kpscolor.smoothen;
		}

		public KPSCOLOR Export() {
			KPSCOLOR col;
			col.kps = (int) nudKps.Value;
			col.smoothen = chkSmoothColor.Checked;
			col.color = btnColor.BackColor;
			return col;
		}

		private void btnColor_Click(object sender, EventArgs e) {
			DialogPositioner.From(FindForm());
			Color? newcol = frmColorPicker.ShowAndEdit(btnColor.BackColor);
			if (newcol == null) {
				return;
			}
			btnColor.BackColor = (Color) newcol;
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			if (OnRemove != null) {
				OnRemove.Invoke(this, null);
			}
		}

		int IComparable<KpsColorControl>.CompareTo(KpsColorControl o) {
			return nudKps.Value.CompareTo(o.nudKps.Value);
		}

	}
}
