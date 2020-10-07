using System.Windows;
using System.Windows.Media;

namespace PaintPassing
{
    public class Rectangle : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(null, Outline, new Rect(StartPoint, EndPoint));
        }
    }
}
