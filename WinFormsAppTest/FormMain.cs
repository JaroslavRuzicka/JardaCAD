using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace JardaCAD
{
    public partial class FormMain : Form
    {
        readonly private int borderSize = 2;

        public FormMain()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // no borders
            //this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.Padding = new Padding(borderSize);
            //this.BackColor = Color.FromArgb(98, 102, 244);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void titleBar_MouseDown(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        protected override void WndProc(ref Message message)
        {

            const int WM_SYSCOMMAND = 0x0083;
            if (message.Msg == WM_SYSCOMMAND && message.WParam.ToInt32() == 1)
            {
                return;
            }

            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }

        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Top);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Left);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Right);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Bottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int borderWidth = 3; // you can rename this variable if you like

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, borderWidth); } }
        Rectangle Left { get { return new Rectangle(0, 0, borderWidth, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, this.ClientSize.Width, borderWidth); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, borderWidth, borderWidth); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, borderWidth); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }

        private void FormMain_Load(object sender, EventArgs e)
        {
             buttonExitApp.MouseClick += TitleBar.Mouse_Click_Exit;
             buttonMaximazeApp.MouseClick += TitleBar.Mouse_Click_Maximaze;
             buttonMinimazeAp.MouseClick += TitleBar.Mouse_Click_Minimize;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(7);
                    break;
                case FormWindowState.Normal:
                    if(this.Padding.Top != borderSize)
                    {
                        this.Padding = new Padding(borderSize);
                    } 
                    break;

            }
        }
    }
}