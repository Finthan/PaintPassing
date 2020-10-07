using System;
using System.Windows;
using System.Windows.Input;

namespace PaintPassing.Tools
{
    class ZoomTool : Tool
    {
        private MouseButton mouseButton;
        private Point startPoint;

        public override void MouseDown(Point startPoint, MouseButton mouseButton)
        {
            this.startPoint = startPoint;
            this.mouseButton = mouseButton;
        }

        public override void MouseUp()
        {
            if (mouseButton == MouseButton.Left)
                Left_Click(startPoint);
            else if (mouseButton == MouseButton.Right)
                Right_Click(startPoint);
        }

        private void Left_Click(Point startPoint)
        {
            if (MainWindow.viewPort.Scale * 2 > 16) return;

            MainWindow.viewPort.Scale *= 2;

            var delta = new MainWindow.ViewPort
            {
                X = startPoint.X - MainWindow.Canv.ActualWidth / 16,
                Y = startPoint.Y - MainWindow.Canv.ActualHeight / 16,
                Scale = 2
            };

            delta.X = -Math.Abs(delta.X);
            delta.Y = -Math.Abs(delta.Y);

            Change_ViewPort(delta);
        }

        private void Right_Click(Point startPoint)
        {
            if (MainWindow.viewPort.Scale / 2 < 0.25) return;

            MainWindow.viewPort.Scale /= 2;

            var delta = new MainWindow.ViewPort
            {
                X = startPoint.X - MainWindow.Canv.ActualWidth / 4,
                Y = startPoint.Y - MainWindow.Canv.ActualHeight / 4,
                Scale = 0.5
            };

            delta.X = Math.Abs(delta.X);
            delta.Y = Math.Abs(delta.Y);

            Change_ViewPort(delta);
        }

        private void Change_ViewPort(MainWindow.ViewPort delta)
        {
            foreach (var shape in MainWindow.Shapes)
            {
                shape.StartPoint = new Point
                {
                    X = shape.StartPoint.X * delta.Scale + delta.X,
                    Y = shape.StartPoint.Y * delta.Scale + delta.Y
                };

                shape.EndPoint = new Point
                {
                    X = shape.EndPoint.X * delta.Scale + delta.X,
                    Y = shape.EndPoint.Y * delta.Scale + delta.Y
                };

                shape.Thickness *= delta.Scale;
            }
        }
    }
}