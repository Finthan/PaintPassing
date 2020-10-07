using System.Windows;
using System.Windows.Media;

namespace PaintPassing
{
    public class Rectangle : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var pen = new Pen(new SolidColorBrush(Outline), Thickness);
            drawingContext.DrawRectangle(null, pen, new Rect(StartPoint, EndPoint));
        }
    }
}
