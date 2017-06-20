using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace osukps {
	public partial class frmMain : Form {
		private const byte MAX_BUTTONS = 10;
		private const byte INITIAL_BUTTONS = 4;
		private KpsHandler kpsHandler;
		private KpsButton[] btns;
		private byte buttonCount;
		private bool settingsModified;
		public frmMain() {
			InitializeComponent();

			pnlInfo.MouseUp += f_MouseUp;
			pnlInfo.MouseDown += f_MouseDown;
			pnlInfo.MouseMove += f_MouseMove;
			lblTotal.MouseUp += f_MouseUp;
			lblTotal.MouseDown += f_MouseDown;
			lblTotal.MouseMove += f_MouseMove;
			lblKps.MouseUp += f_MouseUp;
			lblKps.MouseDown += f_MouseDown;
			lblKps.MouseMove += f_MouseMove;

			kpsHandler = new KpsHandler(lblKps, lblTotal);
			btns = new KpsButton[MAX_BUTTONS];
			for (int i = 0; i < MAX_BUTTONS; i++) {
				KpsButton n = new KpsButton(i);
				n.settingChangedEvent += n_settingChangedEvent;
				pnlKeys.Controls.Add(n);
				btns[i] = n;
			}
			SetButtonCount(INITIAL_BUTTONS);

			loadSettings();
		}

		private void n_settingChangedEvent(object sender, EventArgs e) {
			settingsModified = true;
		}

		#region inidll
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
		#endregion

		#region dragcodez
		private bool moveForm;
		private Point moveOffset;

		private void f_MouseDown(object sender, MouseEventArgs e) {
			moveForm = true;
			moveOffset = e.Location;
		}

		private void f_MouseUp(object sender, MouseEventArgs e) {
			moveForm = false;
		}

		private void f_MouseMove(object sender, MouseEventArgs e) {
			if (moveForm) {
				this.Location = new Point(this.Location.X + (e.Location.X - moveOffset.X), this.Location.Y + (e.Location.Y - moveOffset.Y));
			}
		}
		#endregion

		private void tmrProcess_Tick(object sender, EventArgs e) {
			byte keyCount = 0;
			for (int i = 0; i < buttonCount; i++) {
				keyCount += btns[i].Process();
			}
			kpsHandler.Update(keyCount);
		}

		private void SetButtonCount(byte buttonCount) {
			this.buttonCount = Math.Max((byte) 1, Math.Min(MAX_BUTTONS, buttonCount));
			for (int i = 0; i < MAX_BUTTONS; i++) {
				btns[i].Visible = (i < this.buttonCount);
			}
			// because autosize derps
			Size = new Size(buttonCount * 40 + pnlInfo.Width, 36);
		}

		private void tsiExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void tsiAddButton_Click(object sender, EventArgs e) {
			SetButtonCount(++buttonCount);
		}

		private void tsiRemoveButton_Click(object sender, EventArgs e) {
			SetButtonCount(--buttonCount);
		}

		private void tsiReset_Click(object sender, EventArgs e) {
			kpsHandler.ResetTotal();
		}

		private void frmMain_Load(object sender, EventArgs e) {

		}

		private void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

		}

		private void saveKeySettingsToolStripMenuItem_Click(object sender, EventArgs e) {
			saveSettings();
		}

		private void pnlInfo_Paint(object sender, PaintEventArgs e) {

		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
			kpsHandler.resetmax();
		}

		private void loadKeySetupToolStripMenuItem_Click(object sender, EventArgs e) {
			loadSettings();
		}

		private void saveSettings() {
			WritePrivateProfileString("Count", "count", buttonCount.ToString(), "./setting.ini");

			for (var i = 0; i < buttonCount; i++) {
				var b = btns[i].mykey();
				WritePrivateProfileString("KEY", "key" + (i + 1), b.ToString(), "./setting.ini");
			}
			for (var i = 0; i < buttonCount; i++) {
				var b = btns[i].mystring();
				WritePrivateProfileString("TEXT", "text" + (i + 1), b.ToString(), "./setting.ini");
			}
			settingsModified = false;
		}

		private void loadSettings() {
			var tmp = 0;
			StringBuilder temp = new StringBuilder(255);
			GetPrivateProfileString("Count", "count", "null", temp, 255, "./setting.ini");
			tmp = Int32.Parse(temp.ToString());
			buttonCount = (byte) tmp;
			for (var i = 0; i < buttonCount; i++) {
				GetPrivateProfileString("KEY", "key" + (i + 1), "null", temp, 255, "./setting.ini");
				tmp = Int32.Parse(temp.ToString());
				btns[i].KeySetup(tmp);
			}
			for (var i = 0; i < buttonCount; i++) {
				GetPrivateProfileString("TEXT", "text" + (i + 1), "null", temp, 255, "./setting.ini");
				btns[i].LabelSetup(temp.ToString());
			}
			SetButtonCount(buttonCount);
			settingsModified = false;
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			if (!settingsModified) {
				return;
			}
			DialogResult res = MessageBox.Show("Settings changed, save now?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (res == DialogResult.Cancel) {
				e.Cancel = true;
			} else if (res == DialogResult.Yes) {
				saveSettings();
			}
		}

	}
}
