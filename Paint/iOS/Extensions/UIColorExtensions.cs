using Paint.Draw;
using UIKit;

namespace Paint.iOS.Extensions
{
    public static class UIColorExtensions
    {
        public static Color GetColor(this UIColor color)
        {
            var res = new Color(
                (byte)(color.CGColor.Components[0] * 255),
                (byte)(color.CGColor.Components[1] * 255),
                (byte)(color.CGColor.Components[2] * 255)
                );
            return res;
        }
        
        public static UIColor GetColor(this Color color)
        {
            var res = UIColor.FromRGB(color.Red, color.Green, color.Blue);
            return res;
        }
    }
}