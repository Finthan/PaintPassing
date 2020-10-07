using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;
using MouseButton = System.Windows.Input.MouseButton;

namespace PaintPassing.Tools
{
    class EllipseTool : Tool
    {
        private Ellipse ellipse = new Ellipse();
        public override void MouseDown(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDown(startPoint, mouseButton);

            ellipse.StartPoint = startPoint;
            ellipse.EndPoint = startPoint;

            ellipse.Thickness = Configurator.Thickness;
            ellipse.Outline = Configurator.Outline;
        }

        public override void MouseMove(DrawingContext dc, Point endPoint)
        {
            ellipse.EndPoint = endPoint;
            ellipse.Draw(dc);
        }

        public override void MouseUp()
        {
            base.MouseUp();

            MainWindow.Shapes.Add(ellipse.Clone());
        }
    }
}