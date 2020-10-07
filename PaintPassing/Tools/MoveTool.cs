using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;
using MouseButton = System.Windows.Input.MouseButton;

namespace PaintPassing.Tools
{
    class MoveTool : Tool
    {
        private Point start;

        public override void MouseDown(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDown(startPoint, mouseButton);
            start = startPoint;
        }

        public override void MouseMove(DrawingContext dc, Point endPoint)
        {

            var delta = new Point
            {
                X = endPoint.X - start.X,
                Y = endPoint.Y - start.Y
            };

            foreach (var shape in MainWindow.Shapes)
            {
                shape.StartPoint = new Point
                {
                    X = shape.StartPoint.X + delta.X,
                    Y = shape.StartPoint.Y + delta.Y
                };
                shape.EndPoint = new Point
                {
                    X = shape.EndPoint.X + delta.X,
                    Y = shape.EndPoint.Y + delta.Y
                };
            }
            start = endPoint;
        }

        public override void MouseUp()
        {
            base.MouseUp();
        }
    }
}
