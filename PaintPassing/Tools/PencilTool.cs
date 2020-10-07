using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    class PencilTool : Tool
    {
        private Line line = new Line();
        public override void MouseDown(Point startPoint)
        {
            base.MouseDown(startPoint);

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
        }
    }
}