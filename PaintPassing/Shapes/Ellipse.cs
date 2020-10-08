using System;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace PaintPassing
{
    public class Ellipse : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var pen = new Pen(new SolidColorBrush(Outline), Thickness);
            double CenterX;
            double CenterY;
            int x1, y1, x2, y2;
            x1 = (int)StartPoint.X;
            y1 = (int)StartPoint.Y;
            x2 = (int)EndPoint.X;
            y2 = (int)EndPoint.Y;

            CenterX = (x1 + x2) / 2;
            CenterY = (y1 + y2) / 2;

            double RadiusX = Math.Abs(x1 - x2) / 2;
            double RadiusY = Math.Abs(y1 - y2) / 2;

            Point CenterPoint = new Point(CenterX, CenterY);

            drawingContext.DrawEllipse(null, pen, CenterPoint, RadiusX, RadiusY);
        }

        private void Point(double CenterX, double CenterY)
        {
            throw new NotImplementedException();
        }
    }
}
