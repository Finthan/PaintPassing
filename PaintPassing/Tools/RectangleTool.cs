using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    class RectangleTool : Tool
    {
        private Rectangle rectangle = new Rectangle();
        public override void MouseDown(Point startPoint)
        {
            base.MouseDown(startPoint);

            rectangle.StartPoint = startPoint;
            rectangle.EndPoint = startPoint;

            rectangle.Thickness = Configurator.Thickness;
            rectangle.Outline = Configurator.Outline;
        }

        public override void MouseMove(DrawingContext dc, Point endPoint)
        {
            rectangle.EndPoint = endPoint;
            rectangle.Draw(dc);
        }

        public override void MouseUp()
        {
            base.MouseUp();

            MainWindow.Shapes.Add(rectangle.Clone());
        }
    }
}
