﻿using System;
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
		private const string SETTINGS_FILE = "./osukps.ini";
        private bool isHideaddbutton = false;

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
			btns = new KpsButton[MAX_BUTTONS+1];
			for (int i = 0; i < MAX_BUTTONS+1; i++) {
				KpsButton n = new KpsButton(i,this);
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
			for (int i = 0; i < MAX_BUTTONS+1; i++) {
				btns[i].Visible = (i -1+Convert.ToInt32(isHideaddbutton) < this.buttonCount);
                if (!isHideaddbutton)
                {
                    btns[i].isAddbutton = (i == this.buttonCount);
                    btns[i].UpdateLabel(i == this.buttonCount);
                }
            }
            // because autosize derps
            Size = new Size((buttonCount) * 40 + pnlInfo.Width, 36);
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

		private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
			kpsHandler.resetmax();
		}

		private void resetAllToolStripMenuItem_Click(object sender, EventArgs e) {
			tsiReset.PerformClick();
			resetToolStripMenuItem.PerformClick();
		}

		private void saveKeySettingsToolStripMenuItem_Click(object sender, EventArgs e) {
			saveSettings();
		}

		private void loadKeySetupToolStripMenuItem_Click(object sender, EventArgs e) {
			loadSettings();
		}
        private void hideAddButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isHideaddbutton = isHideaddbutton == false;
            SetButtonCount(buttonCount);
        }
        public void addButton(Label lbl)
        {
            lbl.Text = "";
            SetButtonCount(++buttonCount);
        }
		private void saveSettings() {
			WritePrivateProfileString("Count", "count", buttonCount.ToString(), SETTINGS_FILE);

			for (var i = 0; i < buttonCount; i++) {
				var b = btns[i];
				WritePrivateProfileString("KEY", "key" + (i + 1), b.mykey().ToString(), SETTINGS_FILE);
				WritePrivateProfileString("TEXT", "text" + (i + 1), b.mystring().ToString(), SETTINGS_FILE);
				WritePrivateProfileString("COLOR", "acolor" + (i + 1), b.myactivecolor().ToString(), SETTINGS_FILE);
				WritePrivateProfileString("COLOR", "icolor" + (i + 1), b.myinactivecolor().ToString(), SETTINGS_FILE);
			}
            settingsModified = false;
		}

		private void loadSettings() {
			try {
				StringBuilder temp = new StringBuilder(255);
				GetPrivateProfileString("Count", "count", null, temp, 255, SETTINGS_FILE);
				if (temp.Length > 0) buttonCount = (byte) Int32.Parse(temp.ToString());
				for (var i = 0; i < buttonCount; i++) {
					GetPrivateProfileString("KEY", "key" + (i + 1), "", temp, 255, SETTINGS_FILE);
					if (temp.Length > 0) btns[i].KeySetup(Int32.Parse(temp.ToString()));
					GetPrivateProfileString("TEXT", "text" + (i + 1), "", temp, 255, SETTINGS_FILE);
					if (temp.Length > 0) btns[i].LabelSetup(temp.ToString());
					GetPrivateProfileString("COLOR", "acolor" + (i + 1), "", temp, 255, SETTINGS_FILE);
					if (temp.Length > 0) btns[i].ActiveColorSetup(Int32.Parse(temp.ToString()));
					GetPrivateProfileString("COLOR", "icolor" + (i + 1), "", temp, 255, SETTINGS_FILE);
					if (temp.Length > 0) btns[i].InactiveColorSetup(Int32.Parse(temp.ToString()));
				}
				SetButtonCount(buttonCount);
				settingsModified = false;
			} catch (Exception) {
				MessageBox.Show("Failed to load settings");
			}
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

		private void changeInactiveColorToolStripMenuItem_Click(object sender, EventArgs e) {
			Color? newcol = frmColorPicker.ShowAndEdit(btns[0].color.inactive);
			if (newcol == null) {
				return;
			}
			Color nc = (Color) newcol;
			for (var i = 0; i < buttonCount; i++) {
				btns[i].color.inactive = nc;
			}
			settingsModified = true;
		}

		private void changeActiveColorToolStripMenuItem_Click(object sender, EventArgs e) {
			Color? newcol = frmColorPicker.ShowAndEdit(btns[0].color.active);
			if (newcol == null) {
				return;
			}
			Color nc = (Color) newcol;
			for (var i = 0; i < buttonCount; i++) {
				btns[i].color.active = nc;
			}
			settingsModified = true;
		}
    }
}
