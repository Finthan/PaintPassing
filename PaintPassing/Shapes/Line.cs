using System.Windows.Media;

namespace PaintPassing
{
    public class Line : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            double Radius;

            Radius = this.Outline.Thickness/4;

            Pen OutlineEllipse = new Pen(Outline.Brush, this.Outline.Thickness / 2);

            drawingContext.DrawEllipse(Outline.Brush, OutlineEllipse, StartPoint, Radius, Radius);

            drawingContext.DrawEllipse(Outline.Brush, OutlineEllipse, EndPoint, Radius, Radius);

            drawingContext.DrawLine(Outline, StartPoint, EndPoint);
        }
    }
}