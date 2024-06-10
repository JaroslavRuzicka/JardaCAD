using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace JardaCAD
{
    public partial class FormMain : Form
    {
        readonly private int borderSize = 2;
        Canvas canvas = new Canvas();

        public FormMain()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;

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

        new Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, borderWidth); } }
        new Rectangle Left { get { return new Rectangle(0, 0, borderWidth, this.ClientSize.Height); } }
        new Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, this.ClientSize.Width, borderWidth); } }
        new Rectangle Right { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, this.ClientSize.Height); } }

        static Rectangle TopLeft { get { return new Rectangle(0, 0, borderWidth, borderWidth); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, borderWidth); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            int topBarheight = titleBar.Height + panelControl.Height;
            canvas.setHeight(Height - topBarheight);
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
                    if (this.Padding.Top != borderSize)
                    {
                        this.Padding = new Padding(borderSize);
                    }
                    break;

            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonExitApp.MouseClick += MainWindowControl.Mouse_Click_Exit;
            buttonMaximazeApp.MouseClick += MainWindowControl.Mouse_Click_Maximaze;
            buttonMinimazeAp.MouseClick += MainWindowControl.Mouse_Click_Minimize;

            Program.mainForm.Controls.Add(canvas.MainCanvas);
        }

        bool drawLine = false;
        Point point = new Point(0, 0);  
        Point point2 = new Point(542, 123);

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            drawLine = true;
            point = new Point(point.X + 10, point.Y + 10);
            point2 = new Point(point2.X + 20, point2.Y + 20);

            Drawing.point2 = point;
            Drawing.point1 = point2;
            Drawing.test2 = new Point(700, 700);


            this.Refresh();
            //Canvas.Invalidate();



        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}