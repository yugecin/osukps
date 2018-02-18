using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {

	public class KpsButton : Panel {

		private Label label;
		public IKeyHandler keyhandler;
		private int colortimer;
		private int key;
		public KpsButtonColor color;
		public event EventHandler settingChangedEvent;

		public KpsButton(int position) {
			color = new KpsButtonColor();
			Visible = true;
			AutoSize = false;
			Size = new Size(36, 36);
			Location = new Point(40 * position, 0);
			createLabel();
			keyhandler = NoKeyHandler.Get();
			UpdateColor();
		}

		public void KeySetup(int k) {
			key = k;
			keyhandler = new DefKeyHandler(k);
		}

		public void LabelSetup(string t) {
			label.Text = t;
		}

		public void ActiveColorSetup(int c) {
			color.active = Color.FromArgb(c);
		}

		public void InactiveColorSetup(int c) {
			color.inactive = Color.FromArgb(c);
		}

		public void createLabel() {
			label = new Label();
			label.Visible = true;
			label.AutoSize = false;
			label.Size = new Size(36, 36);
			label.Location = new Point(0, 0);
			label.Text = "";
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.ForeColor = Color.White;
			label.Click += KpsButton_Click;
			label.ForeColor = frmMain.FgColor;
			FontHandler.labels.Add(label);
			Controls.Add(label);
		}

		private void KpsButton_Click(object sender, EventArgs e) {
			DialogPositioner.From(FindForm(), PointToScreen(new Point(Width / 2, Height / 2)));
			IKeyHandler newHandler = frmGetKey.ShowDialogAndGetKeyHandler(color, key, label.Text);
			if (newHandler == null) {
				return;
			}
			keyhandler = newHandler;
			key = frmGetKey.yourkey(); //get my key id
			frmGetKey.UpdateLabel(label);
			if (settingChangedEvent != null) {
				settingChangedEvent(null, null);
			}
		}

		//for save key id and label text
		public int mykey() {
			return key;
		}

		public string mystring() {
			return label.Text;
		}

		public int myactivecolor() {
			return color.active.ToArgb();
		}

		public int myinactivecolor() {
			return color.inactive.ToArgb();
		}

		public byte Process() {
			byte result = keyhandler.Handle();
			if (result == 1) {
				colortimer = 255;
				result = 1;
			} else {
				colortimer = Math.Max(colortimer - 15, 0);
			}
			UpdateColor();
			return result;
		}

		public void UpdateColor() {
			float f = colortimer / 255f;
			int r = color.inactive.R + (int) (f * (color.active.R - color.inactive.R));
			int g = color.inactive.G + (int) (f * (color.active.G - color.inactive.G));
			int b = color.inactive.B + (int) (f * (color.active.B - color.inactive.B));
			label.BackColor = Color.FromArgb(255, r, g, b);
		}

		public void OnForeColorChange() {
			label.ForeColor = frmMain.FgColor;
		}

	}
}
