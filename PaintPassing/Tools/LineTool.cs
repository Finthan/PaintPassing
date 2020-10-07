using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;
using MouseButton = System.Windows.Input.MouseButton;

namespace PaintPassing.Tools
{
    class LineTool : Tool
    {
        private Line line = new Line();
        public override void MouseDown(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDown(startPoint, mouseButton);

            line.StartPoint = startPoint;
            line.EndPoint = startPoint;

            line.Thickness = Configurator.Thickness;
            line.Outline = Configurator.Outline;
        }

        public override void MouseMove(DrawingContext dc, Point endPoint)
        {
            line.EndPoint = endPoint;
            line.Draw(dc);
        }

        public override void MouseUp()
        {
            base.MouseUp();

            MainWindow.Shapes.Add(line.Clone());
        }
    }
}
