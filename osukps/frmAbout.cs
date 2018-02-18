using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osukps {
	public partial class frmAbout : Form {

		private const string CHANGELOGURL = "https://raw.githubusercontent.com/yugecin/osukps/master/changelog";
		private readonly int VERSION = Assembly.GetExecutingAssembly().GetName().Version.Major;

		public frmAbout() {
			InitializeComponent();
			Text = string.Format(Text, VERSION);
			lblInfo.Text = string.Format(lblInfo.Text, VERSION);
		}

		private void FollowLink(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start(((LinkLabel) sender).Text);
		}

		private void btnUpdate_Click(object sender, EventArgs e) {
			btnUpdate.Enabled = false;
			btnUpdate.Text = "Checking...";
			Task.Factory.StartNew(DoUpdateCheck);
		}

		private void DoUpdateCheck() {
			string changelog = DownloadChangelog();
			btnUpdate.BeginInvoke((Action) (() => {
				try {
					if (changelog == null) {
						btnUpdate.Enabled = true;
						btnUpdate.Text = "Check failed - click to retry";
						return;
					}

					changelog = changelog.Replace("\r\n", "\n");

					int latestVersion;
					string latestTag;
					ExtractLatestVersionAndTag(changelog, out latestVersion, out latestTag);

					if (latestTag == null) {
						btnUpdate.Enabled = true;
						btnUpdate.Text = "Invalid response - click to retry";				
						return;
					}

					btnUpdate.Text = "Update check finished";
					Size = new Size(Size.Width, 292);
					txtChangelog.Visible = true;
					txtChangelog.Lines = StripChangelog(changelog, latestVersion - VERSION).Split('\n');
					lblDownload.Visible = true;
					lblDownload.Text = string.Format(lblDownload.Text, latestTag);
				} catch (Exception e) {
					string msg = "Something went horribly wrong: " + e.Message;
					MessageBox.Show(msg, "osukps", MessageBoxButtons.OK, MessageBoxIcon.Error);
					btnUpdate.Enabled = true;
					btnUpdate.Text = "Check failed - click to retry";
					return;
				}
			}));
		}

		private void ExtractLatestVersionAndTag(string changelog, out int version, out string tag) {
			if (changelog.Length == 0 || changelog[0] != 'v') {
				goto err;
			}

			int hyphen = changelog.IndexOf('-');
			if (hyphen < 2) {
				goto err;
			}

			if (!int.TryParse(changelog.Substring(1, hyphen - 1), out version)) {
				goto err;
			}

			int end = changelog.IndexOf('\n');
			if (end < hyphen + 2) {
				goto err;
			}

			tag = changelog.Substring(hyphen + 1, end - hyphen - 1);
			return;
		err:
			version = 0;
			tag = null;
		}

		private string StripChangelog(string changelog, int versionsBehind) {
			if (versionsBehind < 1) {
				return "this is the latest version! yey!";
			}

			int startIdx = 0;
			int endIdx;
			do {
				endIdx = changelog.IndexOf("\n\n", startIdx);
				if (endIdx == -1) {
					return changelog;
				}
				startIdx = endIdx + 1;
			} while (--versionsBehind > 0);

			return changelog.Substring(0, endIdx);
		}

		private string DownloadChangelog() {
			byte[] response = null;
			using (WebClient client = new WebClient()) {
				client.Encoding = Encoding.UTF8;
				try {
					response = client.DownloadData(CHANGELOGURL);
				} catch(Exception) {
					return null;
				}
			}
			return Encoding.Default.GetString(response);
		}

		private void frmAbout_Load(object sender, EventArgs e) {
			DialogPositioner.ApplyTo(this);
		}

	}
}
