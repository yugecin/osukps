using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace osukps {
	public partial class frmMain : Form {

		public const byte MAX_KPS_COLORS = 30;
		private const byte MAX_BUTTONS = 10;
		private const byte INITIAL_BUTTONS = 4;
		private BpmHandler bpmHandler;
		private KpsHandler kpsHandler;
		private KpsButton[] btns;
		private byte buttonCount;
		private bool settingsModified;
		private uint recordingstate;
		private int reckey;
		private string settingsFile = "osukps.ini";

		public static KPSCOLOR[] kpscolors = new KPSCOLOR[MAX_KPS_COLORS];
		public static int kpscolorscount;

		public frmMain() {
			CultureInfo customCulture = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			Thread.CurrentThread.CurrentCulture = customCulture;

			InitializeComponent();
			InitializeButtonCountComponent();
			InitializeStartStopRecHotkeyComponent();

			kpscolors[0].kps = 5;
			kpscolors[0].color = Color.FromArgb(255, 0, 190, 255);
			kpscolors[0].smoothen = false;
			kpscolors[1].kps = 10;
			kpscolors[1].color = Color.FromArgb(255, 248, 0, 0);
			kpscolors[1].smoothen = false;
			kpscolorscount = 2;

			FontHandler.labels.Add(lblKps);
			FontHandler.labels.Add(lblTotal);

			tmrProcess.Interval = 1;

			pnlInfo.MouseUp += f_MouseUp;
			pnlInfo.MouseDown += f_MouseDown;
			pnlInfo.MouseMove += f_MouseMove;
			lblTotal.MouseUp += f_MouseUp;
			lblTotal.MouseDown += f_MouseDown;
			lblTotal.MouseMove += f_MouseMove;
			lblKps.MouseUp += f_MouseUp;
			lblKps.MouseDown += f_MouseDown;
			lblKps.MouseMove += f_MouseMove;
			pnlKeys.MouseUp += f_MouseUp;
			pnlKeys.MouseDown += f_MouseDown;
			pnlKeys.MouseMove += f_MouseMove;

			bpmHandler = new BpmHandler(lblBpm);

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
			if (FontHandler.currentFont == null) {
				FontHandler.resetFont();
			}
		}

		private void InitializeButtonCountComponent() {
			for (int i = 1; i < MAX_BUTTONS + 1; i++) {
				var b = new ToolStripMenuItem() {
					Tag = i,
					Text = i.ToString(),
				};
				b.Click += ButtonCount_Click;
				b.Click += n_settingChangedEvent;
				buttonCountToolStripMenuItem.DropDownItems.Add(b);
			}
		}

		private void InitializeStartStopRecHotkeyComponent() {
			for (int i = 0; i < 12;) {
				var b = new ToolStripMenuItem() {
					Tag = 0x70 + i,
					Text = "F" + (++i).ToString(),
				};
				b.Click += SSRHotkey_Click;
				b.Click += n_settingChangedEvent;
				startStopRecHotkeyToolStripMenuItem.DropDownItems.Add(b);
			}
		}

		private void ButtonCount_Click(object sender, EventArgs e) {
			SetButtonCount((byte) (int) (sender as ToolStripItem).Tag);
		}

		private void SSRHotkey_Click(object sender, EventArgs e) {
			if (!(sender is ToolStripMenuItem)) {
				return;
			}
			int nk = (int) ((ToolStripMenuItem) sender).Tag;
			if (nk == reckey) {
				return;
			}
			reckey = nk;
			UpdateSSRHotkeyActiveItem();
			settingsModified = true;
		}

		private void UpdateSSRHotkeyActiveItem() {
			int idx = reckey;
			if (idx > 0) {
				idx -= 0x6F;
			}
			foreach (var itm in startStopRecHotkeyToolStripMenuItem.DropDownItems) {
				((ToolStripMenuItem) itm).Checked = idx-- == 0;
			}
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

		private int previousbuttonstate = 0;
		private void tmrProcess_Tick(object sender, EventArgs e) {
			byte keyCount = 0;
			uint eventmask = 0;
			for (int i = 0; i < buttonCount; i++) {
				byte state = btns[i].Process();
				if (state == 1 && ((previousbuttonstate >> i) & 1) == 0) {
					previousbuttonstate |= 1 << i;
					keyCount += state;
				} else if (state == 0) {
					previousbuttonstate &= ~(1 << i);
				}
				eventmask = (eventmask << 1) | state;
			}
			eventmask <<= (MAX_BUTTONS - buttonCount);
			if (keyCount > 0) {
				bpmHandler.OnKeypress();
			}
			kpsHandler.Update(keyCount);
			UpdateRecord(eventmask);
		}

		private void SetButtonCount(byte buttonCount) {
			this.buttonCount = Math.Max((byte) 1, Math.Min(MAX_BUTTONS, buttonCount));
			SetVisibleButtonCount(buttonCount);
			hideButtonsToolStripMenuItem.Checked = false;
		}

		private void SetVisibleButtonCount(byte buttonCount) {
			for (int i = 0; i < MAX_BUTTONS; i++) {
				btns[i].Visible = (i < buttonCount);
			}
			// because autosize derps
			pnlKeys.Size = new Size(buttonCount * 40, 36);
			Size = new Size(pnlKeys.Width + pnlInfo.Width, 36);
		}

		private void hideButtonsToolStripMenuItem_Click(object sender, EventArgs e) {
			settingsModified = true;
			UpdateHideButtonsMenuItem(hideButtonsToolStripMenuItem.Checked = !hideButtonsToolStripMenuItem.Checked);
		}

		private void UpdateHideButtonsMenuItem(bool dohide) {
			if (dohide) {
				hideButtonsToolStripMenuItem.Text = "Show buttons";
				SetVisibleButtonCount(0);
				return;
			}

			hideButtonsToolStripMenuItem.Text = "Hide buttons";
			SetVisibleButtonCount(this.buttonCount);
		}

		private void tsiExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void tsiResetKeys_Click(object sender, EventArgs e) {
			kpsHandler.SetTotal(0);
		}

		private void tsiResetMaxKPS_Click(object sender, EventArgs e) {
			kpsHandler.SetMax(0);
		}

		private void tsiResetBoth_Click(object sender, EventArgs e) {
			kpsHandler.SetTotal(0);
			kpsHandler.SetMax(0);
		}

		private void saveKeySettingsToolStripMenuItem_Click(object sender, EventArgs e) {
			saveSettings();
		}

		private void loadKeySetupToolStripMenuItem_Click(object sender, EventArgs e) {
			loadSettings();
		}

		private void saveSettings() {
			string settingsFile = "./" + this.settingsFile;

			WritePrivateProfileString("Count", "count", buttonCount.ToString(), settingsFile);
			WritePrivateProfileString("Count", "hide", hideButtonsToolStripMenuItem.Checked.ToString(), settingsFile);
			WritePrivateProfileString("Font", "family", FontHandler.currentFont.FontFamily.Name, settingsFile);
			WritePrivateProfileString("Font", "size", FontHandler.currentFont.Size.ToString(), settingsFile);
			WritePrivateProfileString("Font", "bold", FontHandler.currentFont.Style == FontStyle.Bold ? "y":"n", settingsFile);
			WritePrivateProfileString("Stuff", "reckey", reckey.ToString(), settingsFile);
			WritePrivateProfileString("Colors", "kps", SerializeKpsColors(kpscolors, kpscolorscount), settingsFile);

			for (var i = 0; i < MAX_BUTTONS; i++) {
				var b = btns[i];
				WritePrivateProfileString("KEY", "key" + (i + 1), b.mykey().ToString(), settingsFile);
				WritePrivateProfileString("TEXT", "text" + (i + 1), b.mystring().ToString(), settingsFile);
				WritePrivateProfileString("COLOR", "acolor" + (i + 1), b.myactivecolor().ToString(), settingsFile);
				WritePrivateProfileString("COLOR", "icolor" + (i + 1), b.myinactivecolor().ToString(), settingsFile);
			}
			settingsModified = false;
		}

		private void loadSettings() {
			string settingsFile = "./" + this.settingsFile;
			bool tmpb;
			string section = "";
			string key = "";
			try {
				StringBuilder temp = new StringBuilder(32);
				GetPrivateProfileString(section = "Count", key = "count", "4", temp, 32, settingsFile);
				buttonCount = (byte) Int32.Parse(temp.ToString());
				SetButtonCount(buttonCount);
				GetPrivateProfileString(section = "Count", key = "hide", "False", temp, 32, settingsFile);
				if (bool.TryParse(temp.ToString(), out tmpb)) {
					hideButtonsToolStripMenuItem.Checked = tmpb;
					UpdateHideButtonsMenuItem(tmpb);
				}
				GetPrivateProfileString(section = "Stuff", key = "reckey", "0", temp, 32, settingsFile);
				reckey = Int32.Parse(temp.ToString());
				UpdateSSRHotkeyActiveItem();
				GetPrivateProfileString(section = "Colors", key = "kps", "", temp, 128, settingsFile);
				string kpscols = temp.ToString();
				if (kpscols.Length > 0) {
					LoadKpsColors(kpscols);
				}

				for (var i = 0; i < MAX_BUTTONS; i++) {
					GetPrivateProfileString(section = "KEY", key = "key" + (i + 1), "", temp, 32, settingsFile);
					if (temp.Length > 0) btns[i].KeySetup(Int32.Parse(temp.ToString()));
					GetPrivateProfileString(section = "TEXT", key = "text" + (i + 1), "", temp, 32, settingsFile);
					if (temp.Length > 0) btns[i].LabelSetup(temp.ToString());
					GetPrivateProfileString(section = "COLOR", key = "acolor" + (i + 1), "", temp, 32, settingsFile);
					if (temp.Length > 0) btns[i].ActiveColorSetup(Int32.Parse(temp.ToString()));
					GetPrivateProfileString(section = "COLOR", key = "icolor" + (i + 1), "", temp, 32, settingsFile);
					if (temp.Length > 0) btns[i].InactiveColorSetup(Int32.Parse(temp.ToString()));
				}

				GetPrivateProfileString(section = "Font", key = "family", "", temp, 32, settingsFile);
				string fontfam = temp.ToString();
				GetPrivateProfileString(section = "Font", key = "size", "", temp, 32, settingsFile);
				string fontsize = temp.ToString();
				GetPrivateProfileString(section = "Font", key = "bold", "", temp, 32, settingsFile);
				string fontbold = temp.ToString();
				LoadFont(fontfam, fontsize, fontbold);
				settingsModified = false;
			} catch (Exception) {
				MessageBox.Show(string.Format("Failed to load settings at section '[{0}]' key '{1}'", section, key));
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
			DialogPositioner.From(this);
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
			DialogPositioner.From(this);
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

		private void changeFontToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				if (fontDialog.ShowDialog() == DialogResult.OK) {
					FontHandler.changeFont(fontDialog.Font);
					settingsModified = true;
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), ex.Message);
			}
		}

		private void resetFontToolStripMenuItem_Click(object sender, EventArgs e) {
			FontHandler.resetFont();
			settingsModified = true;
		}

		private void LoadFont(string fontfam, string fontsize, string bold) {
			if (fontfam.Length == 0 || fontsize.Length == 0 || bold.Length == 0) {
				return;
			}
			try {
				Font f = new Font(fontfam, float.Parse(fontsize), bold == "y" ? FontStyle.Bold : FontStyle.Regular);
				FontHandler.changeFont(f);
			} catch (Exception) {}
		}

		private void cmsStartStopRecording_Click(object sender, EventArgs e) {
			switch (recordingstate) {
			case RS_PLAYBACK:
			case RS_NONE: StartRecording(); break;
			case RS_RECORDING: StopRecording(); break;
			}
		}

		private void cmsPlaybackRecording_Click(object sender, EventArgs e) {
			switch (recordingstate) {
			case RS_NONE:
			case RS_RECORDING: StartPlayback(); break;
			case RS_PLAYBACK: StopPlayback(); break;
			}
		}

		private void tsiAbout_Click(object sender, EventArgs e) {
			DialogPositioner.From(this);
			DialogPositioner.preferSouth = true;
			new frmAbout().Show();
		}

		private void cms_Opening(object sender, CancelEventArgs e) {
			saveKeySettingsToolStripMenuItem.DropDownItems.Clear();
			saveKeySettingsToolStripMenuItem.DropDownItems.Add(newConfigurationToolStripMenuItem);
			saveKeySettingsToolStripMenuItem.DropDownItems.Add(currentConfigurationToolStripMenuItem);
			saveKeySettingsToolStripMenuItem.DropDownItems.Add(toolStripSeparator6);

			loadKeySetupToolStripMenuItem.DropDownItems.Clear();

			string[] configs = Directory.GetFiles("./", "*.ini");
			if (configs.Length == 0) {
				loadKeySetupToolStripMenuItem.DropDownItems.Add(noConfigurationsFoundToolStripMenuItem);
				return;
			}

			foreach (string c in configs) {
				string name = c;
				if (name.StartsWith("./") && name.Length > 2) {
					name = name.Substring(2);
				}

				ToolStripMenuItem tsmi;

				tsmi = new ToolStripMenuItem(name);
				tsmi.Click += OnLoadSettingsFileClick;
				loadKeySetupToolStripMenuItem.DropDownItems.Add(tsmi);

				if (name == settingsFile) {
					continue;
				}

				tsmi = new ToolStripMenuItem(name);
				tsmi.Click += OnSaveSettingsFileClick;
				saveKeySettingsToolStripMenuItem.DropDownItems.Add(tsmi);
			}
		}

		private void OnLoadSettingsFileClick(object sender, EventArgs e) {
			if (settingsModified) {
				DialogResult res = MessageBox.Show(
					"Changed settings will be discarded when loading settings. Discard changes and continue loading settings?",
					"",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Question
				);
				if (res != DialogResult.Yes) {
					return;
				}
			}
			changeCurrentSettingsFile(((ToolStripMenuItem) sender).Text);
			loadSettings();
		}

		private void OnSaveSettingsFileClick(object sender, EventArgs e) {
			string filetosave = ((ToolStripMenuItem) sender).Text;
			if (filetosave != settingsFile) {
				DialogResult res = MessageBox.Show(
					"Save current configuration as " + filetosave + "?",
					"",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Question
				);
				if (res != DialogResult.Yes) {
					return;
				}
				changeCurrentSettingsFile(filetosave);
			}
			saveSettings();
		}

		private void changeCurrentSettingsFile(string newfile) {
			currentConfigurationToolStripMenuItem.Text = newfile;
			settingsFile = newfile;
		}

		private void currentConfigurationToolStripMenuItem_Click(object sender, EventArgs e) {
			saveSettings();
		}

		private void newConfigurationToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogPositioner.From(this);
			string name = frmPrompt.Prompt("Save new configuration", "Enter a name for your new configuration.", "", "Save");
			if (name == null) {
				return;
			}
			changeCurrentSettingsFile(name + ".ini");
			saveSettings();
		}

		private void editKPSColorsToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogPositioner.From(this);
			DialogPositioner.preferSouth = true;
			frmKps k = new frmKps();
			if (k.ShowDialog() != DialogResult.OK) {
				return;
			}

			KPSCOLOR[] newcolors = k.GetNewColors();
			if (SerializeKpsColors(kpscolors, kpscolorscount) == SerializeKpsColors(newcolors, newcolors.Length)) {
				return;
			}

			for (int i = 0; i < newcolors.Length; i++) {
				kpscolors[i] = newcolors[i];
			}
			kpscolorscount = newcolors.Length;

			settingsModified = true;
		}

		private string SerializeKpsColors(KPSCOLOR[] colors, int count) {
			StringBuilder b = new StringBuilder();

			for (int i = 0; i < count; i++) {
				KPSCOLOR c = colors[i];
				b.Append("|").Append(c.kps).Append(",").Append(c.color.ToArgb()).Append(",").Append(c.smoothen);
			}

			if (b.Length != 0) {
			     b.Remove(0, 1);
			}

			return b.ToString();
		}

		private void LoadKpsColors(string serializedInput) {
			string[] colors = serializedInput.Split('|');
			kpscolorscount = colors.Length;

			for (int i = 0; i < colors.Length; i++) {
				string[] parts = colors[i].Split(',');
				kpscolors[i].kps = int.Parse(parts[0]);
				kpscolors[i].color = Color.FromArgb(int.Parse(parts[1]));
				kpscolors[i].smoothen = bool.Parse(parts[2]);
			}
		}

	}
}
