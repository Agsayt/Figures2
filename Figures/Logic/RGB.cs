using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class RGB
    {

        public float red;
        public float green;
        public float blue;

        public RGB(){
            red = 0;
            green = 0;
            blue = 0;
        }

        public RGB(float c)
        {
            red = c;
            green = c;
            blue = c;
        }

        public RGB(float r, float g, float b)
        {
            red = r;
            green = g;
            blue = b;
        }

        public static RGB operator +(RGB a, RGB b)
        {
            var nred = a.red + b.red;
            var ngreen = a.green + b.green;
            var nblue = a.blue + b.blue;

            if (nred > 255) nred = 255;
            if (ngreen > 255) ngreen = 255;
            if (nblue > 255) ngreen = 255;

            return new RGB(nred, ngreen, nblue);
        }

        public static RGB operator *(RGB a, float x)
        {
            var nred = a.red * x;
            var ngreen = a.green * x;
            var nblue = a.blue * x;

            if (nred > 255) nred = 255;
            if (ngreen > 255) ngreen = 255;
            if (nblue > 255) nblue = 255;

            return new RGB(nred, ngreen, nblue);
        }

        public Color GetColor()
        {
            Color color = new Color();
            red = Math.Min(Math.Max(red *255, 0), 255);
            green = Math.Min(Math.Max(green *255, 0), 255);
            blue = Math.Min(Math.Max(blue *255, 0), 255);
            color = Color.FromArgb(255, (int)red, (int)green, (int)blue);

            return color;
        }

        public RGB GetRandom()
        {
            var rnd = new Random();
            return new RGB(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
    }
}
