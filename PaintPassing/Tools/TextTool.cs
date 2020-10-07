using Point = System.Windows.Point;
using DrawingContext = System.Windows.Media.DrawingContext;

namespace PaintPassing.Tools
{
    class TextTool : Tool
    {
        private Text text = new Text();
        public override void MouseDown(Point startPoint)
        {
            base.MouseDown(startPoint);

            text.StartPoint = startPoint;
            text.EndPoint = startPoint;

            text.Thickness = Configurator.Thickness;
            text.Outline = Configurator.Outline;
        }

        public override void MouseMove(DrawingContext dc, Point endPoint)
        {
            text.EndPoint = endPoint;
            text.Draw(dc);
        }

        public override void MouseUp()
        {
            base.MouseUp();

            MainWindow.Shapes.Add(text.Clone());
        }
    }
}