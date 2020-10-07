using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintPassing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>]
    public partial class MainWindow : Window
    {
        int WidthLine;

        bool Move = false;

        public Point point = new Point();

        Brush ColorMain = Brushes.Black;

        enum Func
        {
            Line,
            Rectangle,
            Ellipse,
            Pencil,
            Text
        }

        Shape Shape;
        List<Shape> Shapes = new List<Shape>();
        Func func;

        public MainWindow()
        {

            InitializeComponent();
            Canv.Children.Add(visualHost);

            visualHost.Redraw(Shapes);

            func = Func.Line;
        }

        public VisualHost visualHost = new VisualHost();



        private void Canv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (!Move)
            {
                if (func == Func.Pencil)
                {
                    Shape.EndPoint = e.GetPosition(Canv);
                    var dv = new DrawingVisual();
                    using (var dc = dv.RenderOpen())
                    {
                        Shape.Draw(dc);
                    }
                    if (Shape.StartPoint != Shape.EndPoint)
                    {
                        Shapes.Add(Shape.Clone());
                    }
                    visualHost.Redraw(Shapes);
                    Shape.StartPoint = Shape.EndPoint;
                }
                else
                {
                    Shape.EndPoint = e.GetPosition(Canv);
                    var dv = new DrawingVisual();
                    using (var dc = dv.RenderOpen())
                    {
                        
                    }
                    visualHost.Redraw(Shapes);
                    visualHost.AddChild(dv);
                }
            }
            else
            {
                var End = e.GetPosition(Canv);
                var delta = new Point
                {
                    X = End.X - point.X,
                    Y = End.Y - point.Y
                };

                foreach (var shape in Shapes)
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
                point = End;
                visualHost.Redraw(Shapes);
            }
        }

        private void Canv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WidthLine = Convert.ToInt32(TextInput.Text);
            if (e.LeftButton != MouseButtonState.Pressed) return;

            point = e.GetPosition(Canv);

            if (!Move)
            {
                Shape = func switch
                {
                    Func.Line => new Line() { Outline = new Pen(ColorMain, WidthLine) },
                    Func.Rectangle => new Rectangle() { Outline = new Pen(ColorMain, WidthLine) },
                    Func.Ellipse => new Ellipse() { Outline = new Pen(ColorMain, WidthLine) },
                    Func.Pencil => new Line() { Outline = new Pen(ColorMain, WidthLine) },
                    Func.Text => new Text() { Outline = new Pen(ColorMain, WidthLine) },
                    _ => throw new Exception()
                };
                Shape.StartPoint = e.GetPosition(Canv);
            }
            /*
            else if ()
            {

            }
            */
        }

        private void Canv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!Move)
            {
                Shapes.Add(Shape.Clone());
                visualHost.Redraw(Shapes);
            }
        }

        private void ButtonLine_Click(object sender, RoutedEventArgs e)
        {
            func = Func.Line;
            Move = false;
        }

        private void ButtonEllipse_Click(object sender, RoutedEventArgs e)
        {
            func = Func.Ellipse;
            Move = false;
        }

        private void ButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            func = Func.Rectangle;
            Move = false;
        }
        private void ButtonPencil_Click(object sender, RoutedEventArgs e)
        {
            func = Func.Pencil;
            Move = false;
        }
        private void ButtonText_Click(object sender, RoutedEventArgs e)
        {
            func = Func.Text;
            Move = false;
        }
        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            if (ColorPickerWPF.ColorPickerWindow.ShowDialog(out var color))
            {
                ColorMain = new SolidColorBrush(color);
            }
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            Move = true;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Shapes.Clear();
            visualHost.Redraw(Shapes);
            Move = true;
        }
    }
}
