using System;
using System.Drawing;
using System.Windows.Forms;

namespace osukps {
	public partial class frmGetKey : Form {

		private static frmGetKey instance = new frmGetKey();

		int first = 1;

		public static IKeyHandler GetKey(IKeyHandler handler, Point p) {
			instance.Position = p;
			instance.ShowDialog();
			if (instance.Cancelled) {
				return handler;
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

		public Point Position { get; set; }
		public int KeyCode { get; set; }
		public bool Cancelled { get; set; }

		private frmGetKey() {
			InitializeComponent();
			btnOk.Focus();
			btnOk.Select();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e) {
			Cancelled = false;
			Close();
		}

		private void frmGetKey_KeyUp(object sender, KeyEventArgs e) {
			if (first == 1) { //first keydown check
				if (txtKey.Focused) {
					return;
				}
				var tmp = "";
				var key = 0;
				key = (int) e.KeyCode;
				tmp = (new KeysConverter()).ConvertToString(key);

				if (tmp == "ProcessKey") { } else { //valid keycode check
					KeyCode = (int) e.KeyCode;
					lblKey.Text = (new KeysConverter()).ConvertToString(KeyCode);
					txtKey.Text = lblKey.Text;
					e.Handled = true;
					first = 0;
				}
			}
		}

		private void frmGetKey_Load(object sender, EventArgs e) {
			Location = Point.Subtract(Position, new Size(Width / 2, Height / 2));
			lblKey.Text = "[ Press a key ]";
			txtKey.Text = "";
			Cancelled = true;
			first = 1;
		}

		private void lblKey_Click(object sender, EventArgs e) {

		}

		private void txtKey_TextChanged(object sender, EventArgs e) {

		}
	}
}
