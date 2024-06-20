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
    internal static class LineRendering
    {
        public static List<Line> LineList = new ();

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


                Line line = new Line();

                PointF point2Adjusted = new PointF(
                    (tempPoint2.X - originX * scale) / scale, 
                    (tempPoint2.Y - originY * scale) / scale
                    );

                line.Point1 = point1;
                line.Point2 = point2Adjusted;
                line.color = Color.Black;
                line.Selection = Line.SelectionFlagEnum.notSelected;

                point1 = new Point(0, 0);
                point2 = new Point(0, 0);

                LineList.Add(line);
            };
                
        }

        public static void UpdateLines(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //Later change this to currently selected color
            Pen currnetPen = new Pen(Color.Black, 2);

            float scale = canvas.GetCanvasScale();
            float originX = canvas.GetOriginCoordinates().X;
            float originY = canvas.GetOriginCoordinates().Y;


            if (point1.X != point2.X || point1.Y != point2.Y) 
            {
                PointF tempPoint1 = new PointF(
                    (point1.X + originX) * scale,
                    (point1.Y + originY) * scale
                );
                e.Graphics.DrawLine(currnetPen, tempPoint1, point2);
            }

            if (canvas.CanvasState == Canvas.CanvasStateEnum.selection)
            { 
                e.Graphics.Clear(canvas.MainCanvas.BackColor);
            }
            
            if (LineList.Count != 0)
            {
                foreach (var item in LineList) 
                {
                    Color color = Color.Empty;
                    if (item.Selection == Line.SelectionFlagEnum.selected)
                    {
                        color = Color.Aqua;
                    }
                    else
                    {
                        color = item.color;

                    }
                    Pen pen = new Pen(color, 2);

                    PointF point1 = new PointF(
                        (item.Point1.X + originX) * scale,
                        (item.Point1.Y + originY) * scale
                    );
                    
                    PointF point2 = new PointF(
                        (item.Point2.X + originX) * scale,
                        (item.Point2.Y + originY) * scale
                    );
 
                    e.Graphics.DrawLine(pen, point1, point2);
                }
            }
            e.Dispose();
        }
    }
}
