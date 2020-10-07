using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    class EllipseTool : Tool
    {
        private Ellipse ellipse = new Ellipse();
        public override void MouseDown(Point startPoint)
        {
            base.MouseDown(startPoint);

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