using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Logic
{
    abstract class Figure
    {
        public float posX, posY;
        public bool isSelected;
        public int localId;
        public string name;
        public RGB color;

        public Figure()
        {
            color = new RGB();
            color = color.GetRandom();

        }

        public abstract bool IsInside(float x, float y);
        public abstract void Draw(Graphics g);


        override
        public String ToString()
        {
            return name;
        }
    }
}
