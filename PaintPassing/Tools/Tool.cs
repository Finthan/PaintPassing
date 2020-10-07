using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    abstract class Tool
    {
        protected bool leftClick = false;

        public virtual void MouseDown(Point startPoint)
        {
            leftClick = true;
        }

        public virtual void MouseMove(DrawingContext dc, Point endPoint)
        {

        }

        public virtual void MouseUp()
        {
            leftClick = false;
        }
    }
}
