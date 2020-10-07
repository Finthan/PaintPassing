using System.Windows.Media;

namespace PaintPassing
{
    public class Line : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var radius = Thickness / 4;
            var pen = new Pen(new SolidColorBrush(Outline), Thickness);
            var OutlineEllipse = new Pen(pen.Brush, Thickness / 2);

            drawingContext.DrawEllipse(pen.Brush, OutlineEllipse, StartPoint, radius, radius);
            drawingContext.DrawEllipse(pen.Brush, OutlineEllipse, EndPoint, radius, radius);

            drawingContext.DrawLine(pen, StartPoint, EndPoint);
        }
    }
}