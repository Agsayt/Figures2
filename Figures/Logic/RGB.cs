using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Logic
{
    internal class RGB
    {

        public float red;
        public float green;
        public float blue;

        public RGB()
        {

        }

        public RGB(float c)
        {

        }

        public RGB(float r, float g, float b)
        {
            red = r;
            green = g;
            blue = b;
        }

        public static RGB operator +(RGB a, RGB b)
        {
            return new RGB();
        }

        public static RGB operator *(RGB a, float x)
        {
            return new RGB();
        }

        public Color GetColor()
        {

            return new Color();
        }

        public RGB GetRandom()
        {
            var rnd = new Random();
            return new RGB(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
    }
}
