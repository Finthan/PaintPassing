using PaintPassing.Tools;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintPassing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>]
    public partial class MainWindow : Window
    {
        private enum ToolPicker
        {
            Line,
            Rectangle,
            Ellipse,
            Pencil,
            Text,
            Move,
            Zoom
        }

        public struct ViewPort
        {
            public double X, Y, Scale;
        }

        public static List<Shape> Shapes = new List<Shape>();
        public static ViewPort viewPort = new ViewPort() { X = 0, Y = 0, Scale = 1 };
        public static Canvas Canv;

        private VisualHost visualHost = new VisualHost();

        private Dictionary<ToolPicker, Tool> tools = new Dictionary<ToolPicker, Tool> {
            {ToolPicker.Line, new LineTool() },
            {ToolPicker.Rectangle, new RectangleTool() },
            {ToolPicker.Pencil, new PencilTool() },
            {ToolPicker.Ellipse, new EllipseTool() },
            {ToolPicker.Text, new TextTool() },
            {ToolPicker.Move, new MoveTool() },
            {ToolPicker.Zoom, new ZoomTool() },
        };

        private ToolPicker toolPicker;
       

        public MainWindow()
        {

            InitializeComponent();

            Canv = MainCanvas;
            Canv.Children.Add(visualHost);
            visualHost.Redraw(Shapes);

            toolPicker = ToolPicker.Line;
        }

        private void Canv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(Canv);
            tools[toolPicker].MouseDown(point, e.ChangedButton);
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

            if (toolPicker != ToolPicker.Pencil)
                visualHost.Redraw(Shapes);

            visualHost.AddChild(dv);
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

        private void ButtonZoom_Click(object sender, RoutedEventArgs e) => toolPicker = ToolPicker.Zoom;

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
                4 => 8,
                5 => 16,
                _ => throw new ArgumentException(nameof(ThicknessChanger))
            };
        }
    }
}
