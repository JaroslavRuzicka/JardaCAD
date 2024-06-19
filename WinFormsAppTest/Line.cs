using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace JardaCAD
{
    internal static class Line
    {
        private static List<List<PointF>> LineList = new ();

        public static PointF point1 = new PointF(0, 0);
        public static PointF point2 = new PointF(0, 0);
        private static Canvas canvas = MainWindowControl.getCanvas;


        private static PointF tempPoint1 = new PointF(0, 0);
        private static PointF tempPoint2 = new PointF(0, 0);

        private static LineStateEnum lineState = LineStateEnum.buttonClick;
        public static LineStateEnum LineState
        {
            get => lineState;
            set
            {
                lineState = value;
            }
        }

        public enum LineStateEnum
        {
            buttonClick,
            canvasClick,
        }


        public static void DrawLine(MouseEventArgs e)
        {
            float scale = canvas.GetCanvasScale();
            float originX = canvas.GetOriginCoordinates().X;
            float originY = canvas.GetOriginCoordinates().Y;



            if (lineState == LineStateEnum.buttonClick)
            {

                tempPoint1 = e.Location;
                //point1 = e.Location;
                PointF point1Adjusted = new PointF(
                (tempPoint1.X - originX * scale) / scale,
                (tempPoint1.Y - originY * scale) / scale
                );
                point1 = point1Adjusted;
                lineState = LineStateEnum.canvasClick;
            }
            else if (lineState == LineStateEnum.canvasClick)
            {
                tempPoint2 = e.Location;
                lineState = LineStateEnum.buttonClick;
                canvas.CanvasState = Canvas.CanvasStateEnum.selection; 
                canvas.MainCanvas.Invalidate();



                PointF point1Adjusted = new PointF(
                    tempPoint1.X, 
                    tempPoint1.Y
                    );
                PointF point2Adjusted = new PointF(
                    (tempPoint2.X - originX * scale) / scale, 
                    (tempPoint2.Y - originY * scale) / scale
                    );
                List<PointF> temp = new List<PointF>{ point1, point2Adjusted };


                point1 = new Point(0, 0);
                point2 = new Point(0, 0);

                LineList.Add(temp);
            };
                
        }

        public static void UpdateLines(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Pen pen = new Pen(Color.Black, 2);

            float scale = canvas.GetCanvasScale();
            float originX = canvas.GetOriginCoordinates().X;
            float originY = canvas.GetOriginCoordinates().Y;


            if (point1.X != point2.X || point1.Y != point2.Y) 
            {
                PointF tempPoint1 = new PointF(
                    (point1.X + originX) * scale,
                    (point1.Y + originY) * scale
                );
                e.Graphics.DrawLine(pen, tempPoint1, point2);
            }

            if (canvas.CanvasState == Canvas.CanvasStateEnum.selection)
            { 
                e.Graphics.Clear(canvas.MainCanvas.BackColor);
            }
            
            if (LineList.Count != 0)
            {
                foreach (List<PointF> point in LineList) 
                {
                    PointF point1 = new PointF(
                        (point[0].X + originX) * scale,
                        (point[0].Y + originY) * scale
                    );
                    
                    PointF point2 = new PointF(
                        (point[1].X + originX) * scale,
                        (point[1].Y + originY) * scale
                    );

                    e.Graphics.DrawLine(pen, point1, point2);
                }
            }
            e.Dispose();
        }
    }
}
