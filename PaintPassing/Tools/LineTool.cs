using System;
using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    class LineTool : Tool
    {
        private Line line;
        public override void MouseDown(Point startPoint)
        {
            base.MouseDown(startPoint);

            line.StartPoint = startPoint;
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
