using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;
using MouseButton = System.Windows.Input.MouseButton;

namespace PaintPassing.Tools
{
    class RectangleTool : Tool
    {
        private Rectangle rectangle = new Rectangle();
        public override void MouseDown(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDown(startPoint, mouseButton);

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
