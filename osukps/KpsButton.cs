using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {

	public class KpsButton : Panel {

		private Label label;
		public IKeyHandler Handler { get; set; }
		private int colortimer;
		private bool state;
		private int key;
		public KpsButtonColor color;
		public event EventHandler settingChangedEvent;

		public KpsButton(int position) {
			color = new KpsButtonColor();
			Visible = true;
			AutoSize = false;
			Size = new Size(40, 36);
			Location = new Point(40 * position, 0);
			createPanel();
			createLabel();
			Handler = NoKeyHandler.Get();
			UpdateColor();
		}

		public void KeySetup(int k) {
			key = k;
			Handler = new DefKeyHandler(k);
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

		private void createPanel() {
			Panel p = new Panel();
			p.Visible = true;
			p.AutoSize = false;
			p.Size = new Size(4, 36);
			p.Location = new Point(36, 0);
			Controls.Add(p);
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
            label.Font = new System.Drawing.Font(FontHandler.fontName, 9.75F, FontHandler.fontStyle, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			label.Click += KpsButton_Click;
            FontHandler.labels.Add(label);
            Controls.Add(label);
		}

		private void KpsButton_Click(object sender, EventArgs e) {
			Point pt = PointToScreen(new Point(Width / 2, Height / 2 - 150));
			IKeyHandler newHandler = frmGetKey.ShowDialogAndGetKeyHandler(color, key, label.Text, pt);
			if (newHandler == null) {
				return;
			}
			Handler = newHandler;
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
			byte isJustPressed = 0;
			if (Handler.Handle()) {
				colortimer = 255;
				if (!state) {
					state = true;
					isJustPressed = 1;
				}
			} else {
				state = false;
				colortimer = Math.Max(colortimer - 15, 0);
			}
			UpdateColor();
			return isJustPressed;
		}

		public void UpdateColor() {
			float f = colortimer / 255f;
			int r = color.inactive.R + (int) (f * (color.active.R - color.inactive.R));
			int g = color.inactive.G + (int) (f * (color.active.G - color.inactive.G));
			int b = color.inactive.B + (int) (f * (color.active.B - color.inactive.B));
			label.BackColor = Color.FromArgb(255, r, g, b);
		}

	}
}
