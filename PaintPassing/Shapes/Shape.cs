using System.Windows;
using System.Windows.Media;

namespace PaintPassing
{
    public abstract class Shape
    {
        protected Shape()
        {
            StartPoint = new Point(-1, -1);
            EndPoint = new Point(-1, -1);
            Thickness = 1;
            Outline = Colors.Black;
        }

        public virtual Shape Clone() => (Shape)MemberwiseClone();

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public double Thickness { get; set; }

        public Color Outline { get; set; }

        public abstract void Draw(DrawingContext drawingContext);
    }
}