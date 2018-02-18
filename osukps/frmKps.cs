using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace osukps {
	public partial class frmKps : Form {

		private KPSCOLOR[] kpscolors = new KPSCOLOR[frmMain.MAX_KPS_COLORS];
		private int kpscolorcount;
		private int baseHeight;
		private Point basePos;
		private int singleRowHeight;
		private KpsColorControl[] kpscolorcontrols = new KpsColorControl[frmMain.MAX_KPS_COLORS];

		public frmKps() {
			InitializeComponent();
			singleRowHeight = kpsDummy.Height;
			baseHeight = Size.Height - singleRowHeight;
			basePos = kpsDummy.Location;

			for (int i = 0; i < frmMain.MAX_KPS_COLORS; i++) {
				KpsColorControl c = new KpsColorControl();
				c.Use(frmMain.kpscolors[i]);
				c.Anchor = kpsDummy.Anchor;
				c.OnRemove += OnRemoveKpsColor;
				c.Tag = i;
				kpscolorcontrols[i] = c;
				Controls.Add(c);
			}

			Controls.Remove(kpsDummy);
			kpsDummy.Dispose();

			kpscolorcount = frmMain.kpscolorscount;
			UpdateControlsLocations();
			UpdateControlsVisibility();
		}

		private void UpdateControlsVisibility() {
			this.Height = baseHeight + kpscolorcount * singleRowHeight;
			for (int i = 0; i < frmMain.MAX_KPS_COLORS; i++) {
				kpscolorcontrols[i].Visible = i < kpscolorcount;
			}
		}

		private void UpdateControlsLocations() {
			for (int i = 0; i < frmMain.MAX_KPS_COLORS; i++) {
				kpscolorcontrols[i].Location = new Point(basePos.X, basePos.Y + singleRowHeight * i);
				kpscolorcontrols[i].Tag = i;
			}
		}

		private void OnRemoveKpsColor(object sender, EventArgs e) {
			if (--kpscolorcount == 0) {
				UpdateControlsVisibility();
				return;
			}

			int idx = (int) ((KpsColorControl) sender).Tag;
			KpsColorControl c = kpscolorcontrols[idx];
			kpscolorcontrols[idx] = kpscolorcontrols[kpscolorcount];
			kpscolorcontrols[kpscolorcount] = c;
			SortControls();
			UpdateControlsLocations();
			UpdateControlsVisibility();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnSort_Click(object sender, EventArgs e) {
			SortControls();
			UpdateControlsLocations();
		}

		private void SortControls() {
			if (kpscolorcount > 1) {
				Array.Sort(kpscolorcontrols, 0, kpscolorcount);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			if (kpscolorcount == frmMain.MAX_KPS_COLORS) {
				string msg = string.Format("The limit of {0} colors has been reached", frmMain.MAX_KPS_COLORS);
				MessageBox.Show(msg, "osukps", MessageBoxButtons.OK);
				return;
			}

			kpscolorcount++;
			UpdateControlsVisibility();
		}

		private void btnOK_Click(object sender, EventArgs e) {
			SortControls();
			Close();
		}

		public KPSCOLOR[] GetNewColors() {
			KPSCOLOR[] nc = new KPSCOLOR[kpscolorcount];
			for (int i = 0; i < kpscolorcount; i++) {
				nc[i] = kpscolorcontrols[i].Export();
			}
			return nc;
		}

		private void frmKps_Load(object sender, EventArgs e) {
			DialogPositioner.ApplyTo(this);
		}

	}
}
