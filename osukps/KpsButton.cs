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
		private KpsButtonColor color;
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
			Handler = new DefKeyHandler(k);
		}

		public void LabelSetup(string t) {
			label.Text = t;
		}

		private void createPanel() {
			Panel p = new Panel();
			p.Visible = true;
			p.AutoSize = false;
			p.Size = new Size(4, 36);
			p.Location = new Point(36, 0);
			Controls.Add(p);
		}

		private void createLabel() {
			label = new Label();
			label.Visible = true;
			label.AutoSize = false;
			label.Size = new Size(36, 36);
			label.Location = new Point(0, 0);
			label.Text = "";
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.ForeColor = Color.White;
			label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			label.Click += KpsButton_Click;
			Controls.Add(label);
		}

		private void KpsButton_Click(object sender, EventArgs e) {
			Point pt = PointToScreen(new Point(Width / 2, Height / 2 - 150));
			IKeyHandler newHandler = frmGetKey.ShowDialogAndGetKeyHandler(color, pt);
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
