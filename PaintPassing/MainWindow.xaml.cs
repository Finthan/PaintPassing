using PaintPassing.Tools;
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
        enum ToolPicker
        {
            Line,
            Rectangle,
            Ellipse,
            Pencil,
            Text,
            Move
        }

        public static List<Shape> Shapes = new List<Shape>();
        private static VisualHost visualHost = new VisualHost();

        private Dictionary<ToolPicker, Tool> tools = new Dictionary<ToolPicker, Tool> {
            {ToolPicker.Line, new LineTool() },
            {ToolPicker.Rectangle, new RectangleTool() },
            {ToolPicker.Pencil, new PencilTool() },
            {ToolPicker.Ellipse, new EllipseTool() },
            {ToolPicker.Text, new TextTool() },
            {ToolPicker.Move, new MoveTool() },
        };

        ToolPicker toolPicker;

        public MainWindow()
        {

            InitializeComponent();

            Canv.Children.Add(visualHost);
            visualHost.Redraw(Shapes);

            toolPicker = ToolPicker.Line;
        }

        private void Canv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(Canv);
            tools[toolPicker].MouseDown(point);
        }

        private void Canv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            var point = e.GetPosition(Canv);

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                tools[toolPicker].MouseMove(dc, point);
            }
            visualHost.Redraw(Shapes);
            visualHost.AddChild(dv);




            //if (!Move)
            //{
            //    if (toolPicker == ToolPicker.Pencil)
            //    {
            //        Shape.EndPoint = e.GetPosition(Canv);
            //        using (var dc = dv.RenderOpen())
            //        {
            //            Shape.Draw(dc);
            //        }
            //        if (Shape.StartPoint != Shape.EndPoint)
            //        {
            //            Shapes.Add(Shape.Clone());
            //        }
            //        visualHost.Redraw(Shapes);
            //        Shape.StartPoint = Shape.EndPoint;
            //    }
            //}
        }

        private void Canv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tools[toolPicker].MouseUp();
            visualHost.Redraw(Shapes);
        }

        private void ButtonLine_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Line;

        private void ButtonEllipse_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Ellipse;

        private void ButtonRectangle_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Rectangle;

        private void ButtonPencil_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Pencil;

        private void ButtonText_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Text;

        private void ButtonMove_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Move;
        
        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            if (ColorPickerWPF.ColorPickerWindow.ShowDialog(out var color))
            {
                Configurator.Outline = color;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Shapes.Clear();
            visualHost.Redraw(Shapes);
        }

        private void TextInput_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Configurator.Thickness = ThicknessChanger.SelectedIndex switch
            {
                0 => 0.5,
                1 => 1,
                2 => 2,
                3 => 4,
                _ => throw new ArgumentException(nameof(ThicknessChanger))
            };
        }
    }
}
