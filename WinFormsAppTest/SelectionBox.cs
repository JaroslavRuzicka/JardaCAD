using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{


    internal class SelectionBox
    {
        private PointF currentPosition;
        private PointF origin;
        PointF lineTopPoint1 = new PointF(0, 0);
        PointF lineTopPoint2 = new PointF(0, 0);
        PointF lineLeftPoint1 = new PointF(0, 0);
        PointF lineLeftPoint2 = new PointF(0, 0);
        PointF lineBottomPoint1 = new PointF(0, 0);
        PointF lineBottomPoint2 = new PointF(0, 0);
        PointF lineRightPoint1 = new PointF(0, 0);
        PointF lineRightPoint2 = new PointF(0, 0);

        private List<Line> selectedItems = new();

        public PointF Origin
        {
            get => origin;
            set => origin = value;
        }

        private SelectionBoxStateEnum selectionBoxState;


        private enum SelectionBoxStateEnum
        {
            insideSelectionBox,
            passthroughSelectionBox,

        }

        public void DrawSelectionBox(MouseEventArgs e)
        {
            
            currentPosition = e.Location;
            float diffX = currentPosition.X - origin.X;
            float diffY = currentPosition.Y - origin.Y;


            lineTopPoint1 = new PointF(origin.X + diffX, origin.Y);
            lineTopPoint2 = new PointF(origin.X, origin.Y);

            lineLeftPoint1 = new PointF(origin.X, origin.Y + diffY);
            lineLeftPoint2 = new PointF(origin.X, origin.Y);

            lineBottomPoint1 = new PointF(origin.X + diffX, origin.Y + diffY);
            lineBottomPoint2 = new PointF(origin.X, origin.Y + diffY);

            lineRightPoint1 = new PointF(origin.X + diffX, origin.Y + diffY);
            lineRightPoint2 = new PointF(origin.X + diffX, origin.Y);

            if (currentPosition.X - origin.X > 0)
            {
                selectionBoxState = SelectionBoxStateEnum.insideSelectionBox;
                findItemsInSelectionBox();
            }
            else
            {
                selectionBoxState = SelectionBoxStateEnum.passthroughSelectionBox;
                findItemsInSelectionBox();
            }

        }

        public void UpdateSelectionBox(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Empty, 2);

            if (selectionBoxState == SelectionBoxStateEnum.insideSelectionBox)
            {
                pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }else if(selectionBoxState == SelectionBoxStateEnum.passthroughSelectionBox)
            {
                pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            e.Graphics.DrawLine(pen, lineTopPoint1, lineTopPoint2);
            e.Graphics.DrawLine(pen, lineLeftPoint1, lineLeftPoint2);
            e.Graphics.DrawLine(pen, lineBottomPoint1, lineBottomPoint2);
            e.Graphics.DrawLine(pen, lineRightPoint1, lineRightPoint2);

        }

        private void findItemsInSelectionBox()
        {
            foreach(Line item in LineRendering.LineList)
            {
                PointF point1 = item.Point1;
                PointF point2 = item.Point2;
                Canvas canvas = MainWindowControl.getCanvas;
                PointF canvasOrigin = canvas.GetOriginCoordinates();

                float point1XTopDifference = point1.X + canvasOrigin.X - lineTopPoint2.X;
                float point1YTopDifference = point1.Y + canvasOrigin.Y - lineTopPoint2.Y;
                float point1XTRightDifference = point1.X + canvasOrigin.X - lineRightPoint1.X;
                float point1YRightDifference = point1.Y + canvasOrigin.Y - lineRightPoint1.Y;

                float point2XTopDifference = point2.X + canvasOrigin.X - lineTopPoint2.X;
                float point2YTopDifference = point2.Y + canvasOrigin.Y - lineTopPoint2.Y;
                float point2XTRightDifference = point2.X + canvasOrigin.X - lineRightPoint1.X;
                float point2YRightDifference = point2.Y + canvasOrigin.Y - lineRightPoint1.Y;

                if ((point1XTopDifference > 0 &&
                    point1YTopDifference > 0 &&
                    point1XTRightDifference < 0 &&
                    point1YRightDifference < 0) &&
                    (point2XTopDifference > 0 &&
                    point2YTopDifference > 0 &&
                    point2XTRightDifference < 0 &&
                    point2YRightDifference < 0))
                {
                    item.Selection = Line.SelectionFlagEnum.selected;
                    selectedItems.Add(item);
                }
                else if (
                    (point1XTopDifference > 0 &&
                    point1YTopDifference < 0 &&
                    point1XTRightDifference < 0 &&
                    point1YRightDifference > 0) &&
                    (point2XTopDifference > 0 &&
                    point2YTopDifference < 0 &&
                    point2XTRightDifference < 0 &&
                    point2YRightDifference > 0)
                )
                {
                    item.Selection = Line.SelectionFlagEnum.selected;
                    selectedItems.Add(item);

                }
                else if (
                    (point1XTopDifference < 0 &&
                    point1YTopDifference < 0 &&
                    point1XTRightDifference > 0 &&
                    point1YRightDifference > 0) ||
                    (point2XTopDifference < 0 &&
                    point2YTopDifference < 0 &&
                    point2XTRightDifference > 0 &&
                    point2YRightDifference > 0))
                {
                    item.Selection = Line.SelectionFlagEnum.selected;
                    selectedItems.Add(item);
                }
                else if (   
                    (point1XTopDifference < 0 &&
                    point1YTopDifference > 0 &&
                    point1XTRightDifference > 0 &&
                    point1YRightDifference < 0) ||
                    (point2XTopDifference < 0 &&
                    point2YTopDifference > 0 &&
                    point2XTRightDifference > 0 &&
                    point2YRightDifference < 0))
                {
                    item.Selection = Line.SelectionFlagEnum.selected;
                    selectedItems.Add(item);
                }
                
            }
        }
        
        public static void ResetSelection()
        {
            foreach(Line item in LineRendering.LineList)
            {
                item.Selection = Line.SelectionFlagEnum.notSelected;
            }

        }

        public void resetSelectionBox()
        {
            lineTopPoint1 = new PointF(0,0);
            lineTopPoint2 = new PointF(0, 0);
            lineLeftPoint1 = new PointF(0, 0);
            lineLeftPoint2 = new PointF(0, 0);
            lineBottomPoint1 = new PointF(0, 0);    
            lineBottomPoint2 = new PointF(0, 0);
            lineRightPoint1 = new PointF(0, 0);
            lineRightPoint2 = new PointF(0, 0);
        }

    }
}
