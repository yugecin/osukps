using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	public partial class frmGetKey : Form {

		private static frmGetKey instance = new frmGetKey();

		private KpsButtonColor colors;
		private Color oldactivecolor;
		private Color oldinactivecolor;
		private bool keychanged;

		public static IKeyHandler ShowDialogAndGetKeyHandler(KpsButtonColor colors, int prevkey, string prevlabel) {
			instance.colors = colors;
			instance.ActiveControl = null;
			instance.KeyCode = prevkey;
			instance.txtKey.Text = prevlabel;
			instance.ShowDialog();
			if (instance.Cancelled) {
				return null;
			}
			return new DefKeyHandler(instance.KeyCode);
		}

		public static int yourkey() //return key to instance
		{
			return instance.KeyCode;
		}

		public static void UpdateLabel(Label lbl) {
			if (!instance.Cancelled) {
				if (instance.chkShowLabel.Checked) {
					lbl.Text = instance.txtKey.Text;
				} else {
					lbl.Text = "";
				}
			}
		}

		public int KeyCode { get; set; }
		public bool Cancelled { get; set; }

		private frmGetKey() {
			InitializeComponent();
			btnOk.Focus();
			btnOk.Select();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			colors.active = oldactivecolor;
			colors.inactive = oldinactivecolor;
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e) {
			Cancelled = false;
			Close();
		}

		private void frmGetKey_KeyUp(object sender, KeyEventArgs e) {
			if (keychanged) { //first keydown check
				return;
			}
			if (txtKey.Focused) {
				return;
			}
			var tmp = "";
			var key = 0;
			key = (int) e.KeyCode;
			tmp = (new KeysConverter()).ConvertToString(key);

			if (tmp != "ProcessKey") { //valid keycode check
				KeyCode = (int) e.KeyCode;
				lblKey.Text = (new KeysConverter()).ConvertToString(KeyCode);
				txtKey.Text = lblKey.Text;
				e.Handled = true;
				keychanged = true;
			}
		}

		private void frmGetKey_Load(object sender, EventArgs e) {
			DialogPositioner.ApplyTo(this);
			oldactivecolor = colors.active;
			oldinactivecolor = colors.inactive;
			btnColInactive.BackColor = colors.inactive;
			btnColActive.BackColor = colors.active;
			lblKey.Text = "[ Press a key ]";
			Cancelled = true;
			keychanged = false;
		}

		private void btnColInactive_Click(object sender, EventArgs e) {
			DialogPositioner.From(this);
			Color? newcol = frmColorPicker.ShowAndEdit(colors.inactive);
			if (newcol == null) {
				return;
			}
			colors.inactive = (Color) newcol;
			btnColInactive.BackColor = colors.inactive;
		}

		private void btnColActive_Click(object sender, EventArgs e) {
			DialogPositioner.From(this);
			Color? newcol = frmColorPicker.ShowAndEdit(colors.active);
			if (newcol == null) {
				return;
			}
			colors.active = (Color) newcol;
			btnColActive.BackColor = colors.active;
		}
	}
}
