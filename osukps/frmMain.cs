using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osukps
{
	public partial class frmMain : Form
	{
		private const byte MAX_BUTTONS = 10;
		private const byte INITIAL_BUTTONS = 4;
        public int[] key;
		private KpsHandler kpsHandler;
		private KpsButton[] btns;
		private byte buttonCount;
		public frmMain()
		{
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

			kpsHandler = new KpsHandler( lblKps, lblTotal );
			btns = new KpsButton[MAX_BUTTONS];
			for (int i = 0; i < MAX_BUTTONS; i++)
			{
				KpsButton n = new KpsButton( i );
				pnlKeys.Controls.Add( n );
				btns[i] = n;
			}
			SetButtonCount( INITIAL_BUTTONS );
		}
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, int size, string filePath);

#region dragcodez
        private bool moveForm;
		private Point moveOffset;

		private void f_MouseDown( object sender, MouseEventArgs e )
		{
			moveForm = true;
			moveOffset = e.Location;
		}

		private void f_MouseUp( object sender, MouseEventArgs e )
		{
			moveForm = false;
		}

		private void f_MouseMove( object sender, MouseEventArgs e )
		{
			if( moveForm )
			{
				this.Location = new Point( this.Location.X + ( e.Location.X - moveOffset.X ), this.Location.Y + ( e.Location.Y - moveOffset.Y ) );
			}
		}
        #endregion
        public int kpsmax(int max)
        {
            return 1;
        }
		private void tmrProcess_Tick( object sender, EventArgs e )
		{
			byte keyCount = 0;
			for( int i = 0; i < buttonCount; i++ )
			{
				keyCount += btns[i].Process();
			}
			kpsHandler.Update( keyCount );
		}

		private void SetButtonCount( byte buttonCount)
		{
			this.buttonCount = Math.Max( (byte) 1, Math.Min( MAX_BUTTONS, buttonCount ) );
			for (int i = 0; i < MAX_BUTTONS; i++)
			{
				btns[i].Visible = ( i < this.buttonCount );
			}
			// because autosize derps
			Size = new Size( buttonCount * 40 + pnlInfo.Width, 36 );
		}

		private void tsiExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsiAddButton_Click( object sender, EventArgs e )
		{
			SetButtonCount( ++buttonCount );
		}

		private void tsiRemoveButton_Click( object sender, EventArgs e )
		{
			SetButtonCount( --buttonCount );
		}

		private void tsiReset_Click( object sender, EventArgs e )
		{
			kpsHandler.ResetTotal();
		}

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void saveKeySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WritePrivateProfileString("Count", "count", buttonCount.ToString(), "./setting.ini");
            for (var i = 0; i < buttonCount; i++)
            {
                WritePrivateProfileString("INIT_PATH", "key" + (i+1), "Testing" , "./setting.ini");
            }
        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmrMax_Tick(object sender, EventArgs e)
        {
            
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kpsHandler.resetmax();
        }
    }
}
