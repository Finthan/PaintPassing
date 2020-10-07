using Color = System.Windows.Media.Color;

namespace PaintPassing.Tools
{
    static class Configurator
    {
        public static double Thickness { get; set; } = 1;
        public static Color Outline { get; set; } = Color.FromRgb(0, 0, 0);
    }
}
