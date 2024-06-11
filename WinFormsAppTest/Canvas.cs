using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal class Canvas
    {

        public TableLayoutPanel MainCanvas;

        private CanvasStateEnum canvasState = CanvasStateEnum.selection;

        public CanvasStateEnum CanvasState
        {
            get => canvasState;
            set 
            { 
                canvasState = value; 
            }
        }

        public enum CanvasStateEnum
        {
            selection,
            drawLine,
        }

        public Canvas()
        {
            MainCanvas = new TableLayoutPanel();

            SetDoubleBuffer(this.MainCanvas, true);

            //Canvas.Dock = DockStyle.Bottom;
            this.MainCanvas.Height = 150;
            this.MainCanvas.Width = 150;
            this.MainCanvas.BackColor = Color.BlanchedAlmond;
            this.MainCanvas.Name = "Canvas";
            this.MainCanvas.Location = new Point(0, 200);
            this.MainCanvas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.MainCanvas.Dock = DockStyle.Bottom;
            this.MainCanvas.Paint += panelCanvas_Paint;
            this.MainCanvas.MouseMove += panelCanvas_MouseMove;
            this.MainCanvas.MouseClick += panelCanvas_MouseClick;
            this.MainCanvas.Paint += new PaintEventHandler(panelCanvas_Paint);

        }

        public void setHeight(int height)
        {
            this.MainCanvas.Height = height;
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Line.UpdateLines(e);

        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            switch (this.canvasState)
            {
                case CanvasStateEnum.drawLine:
                    Line.DrawLine(e);
                    break;
                default:
                    break;
            }
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.canvasState == CanvasStateEnum.drawLine && Line.LineState == Line.LineStateEnum.canvasClick)
            {
                //Line.curDrawnLine[1] = e.Location;
                Line.point2 = e.Location;
                MainCanvas.Invalidate();
            }
        }

        static void SetDoubleBuffer(Control ctrl, bool DoubleBuffered)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ctrl, new object[] { DoubleBuffered });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
