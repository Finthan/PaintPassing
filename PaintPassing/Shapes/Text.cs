using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace PaintPassing
{
    class Text : Shape
    {
        [Obsolete]
        public override void Draw(DrawingContext drawingContext)
        {
            double CenterX;
            double CenterY;
            int x1, y1, x2, y2;
            x1 = (int)StartPoint.X;
            y1 = (int)StartPoint.Y;
            x2 = (int)EndPoint.X;
            y2 = (int)EndPoint.Y;

            CenterX = (x1 + x2) / 2;
            CenterY = (y1 + y2) / 2;

            Point CenterPoint = new Point(CenterX, CenterY);
            
            string testString = "Lorem";

            FormattedText formattedText = new FormattedText(testString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 32, Brushes.Black)
            {
                MaxTextWidth = 300,
                MaxTextHeight = 240
            };

            drawingContext.DrawText(formattedText, CenterPoint);
        }

        private void Point(double CenterX, double CenterY)
        {
            throw new NotImplementedException();
        }
    }
}
