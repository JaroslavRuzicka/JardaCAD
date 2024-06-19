using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JardaCAD
{
    internal class Canvas
    {

        public TableLayoutPanel MainCanvas;

        private CanvasStateEnum canvasState = CanvasStateEnum.selection;
        private CanvasStateEnum pausedCanvasState = CanvasStateEnum.selection;
        private PointF origin = new PointF(0, 0);
        private PointF panningOrigin = new PointF(0, 0);

        #region Getters and setters
        public PointF GetOriginCoordinates()
        {
            return origin;
        }
        public void SetOriginCoordinates(PointF point)
        {
            origin = point;
        }

        private float canvasScale = 1;
        public void SetCanvasScale(float scale)
        {
            canvasScale = scale;
        }
        public float GetCanvasScale()
        {
            return canvasScale;
        }

        public CanvasStateEnum CanvasState
        {
            get => canvasState;
            set 
            { 
                canvasState = value; 
            }
        }
        #endregion
        #region Canvas properties
        public enum CanvasStateEnum
        {
            selection,
            drawLine,
            panning,
        }

        public Canvas()
        {
            MainCanvas = new TableLayoutPanel();

            SetDoubleBuffer(this.MainCanvas, true);

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
            this.MainCanvas.MouseWheel += panelCanvas_MouseWheel;
            this.MainCanvas.Paint += new PaintEventHandler(panelCanvas_Paint);
            this.MainCanvas.MouseUp += panelCanvas_MouseUp;
            this.MainCanvas.MouseDown += panelCanvas_MouseDown;

        }

        public void setHeight(int height)
        {
            this.MainCanvas.Height = height;
        }
        #endregion
        #region Event listeners
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
           
            Line.UpdateLines(e);
        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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

//            MessageBox.Show(e.Location.ToString());

        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                canvasState = CanvasStateEnum.panning;
                ResetCanvasState();
                MainCanvas.Invalidate();
            }

            if (e.Button == MouseButtons.Middle)
            {
                pausedCanvasState = canvasState;
                canvasState = CanvasStateEnum.panning;
                panningOrigin = e.Location;
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (canvasState == CanvasStateEnum.panning)
            {
                canvasState = pausedCanvasState;
                //ResetCanvasState();
                //Once I add option to draw different objects, think about changing this to 
                //different thing
                if (canvasState != CanvasStateEnum.drawLine)
                {
                    Line.point1 = new Point(0, 0);
                    Line.point2 = new Point(0, 0);
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.canvasState == CanvasStateEnum.drawLine && Line.LineState == Line.LineStateEnum.canvasClick)
            {
                Line.point2 = e.Location;
                
            }else if(canvasState == CanvasStateEnum.panning)
            {
                float Xdif = e.Location.X - panningOrigin.X;
                float Ydif = e.Location.Y - panningOrigin.Y;

                PointF newOrigin = new PointF(
                    GetOriginCoordinates().X + Xdif / canvasScale,
                    GetOriginCoordinates().Y + Ydif / canvasScale
                );


                SetOriginCoordinates(newOrigin);
                panningOrigin = e.Location;
            }
            MainCanvas.Invalidate();
        }

        private void panelCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            //Delta is scroll, one scroll on my mouse is value of 120 up or down,
            //So each scaleValue is 20% up or down (1.2)
            float scaleValue = e.Delta / 100f;
            PointF origin = GetOriginCoordinates();
            PointF mouseLocation = new PointF(e.Location.X + origin.X, e.Location.Y + origin.Y);


            if (scaleValue > 0)
            {
                if (GetCanvasScale() >= 10)
                {
                    return;
                }
                float scale = GetCanvasScale() * scaleValue;
                SetCanvasScale(scale);

                PointF scaledUpMouseLocation = new PointF(
                    mouseLocation.X * scaleValue, 
                    mouseLocation.Y * scaleValue);
                PointF diffMouseLocation = new PointF(
                    scaledUpMouseLocation.X - mouseLocation.X, 
                    scaledUpMouseLocation.Y - mouseLocation.Y);

                PointF newOrigin = new PointF(
                    origin.X - diffMouseLocation.X, 
                    origin.Y - diffMouseLocation.Y);
                
                SetOriginCoordinates(newOrigin);

                MainCanvas.Invalidate();
            }
            else
            {
                if (GetCanvasScale() <= .001)
                {
                    return;
                }
                float scale = GetCanvasScale() / (scaleValue * -1);
                SetCanvasScale(scale);

                PointF scaledUpMouseLocation = new PointF(
                    mouseLocation.X / scaleValue * -1, 
                    mouseLocation.Y / scaleValue * -1);
                PointF diffMouseLocation = new PointF(
                    scaledUpMouseLocation.X - mouseLocation.X, 
                    scaledUpMouseLocation.Y - mouseLocation.Y);

                PointF newOrigin = new PointF(
                    origin.X - diffMouseLocation.X, 
                    origin.Y - diffMouseLocation.Y);

                SetOriginCoordinates(newOrigin);

                MainCanvas.Invalidate();
            }

        }
        #endregion
        #region Other methods
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

        public void ResetCanvasState()
        {
            CanvasState = CanvasStateEnum.selection;
            Line.LineState = Line.LineStateEnum.buttonClick;
        }
        #endregion
    }
}
