using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    abstract class Figure
    {
        public Vec2 pos;
        public bool isSelected;
        public int localId;
        public string name;
        public RGB color;

        public Figure()
        {
            color = new RGB();
            color = color.GetRandom();
        }

        public abstract bool IsInside(Vec2 vec);
        public abstract void Draw(Graphics g);
        public abstract float Sdf(Vec2 p);


        override
        public String ToString()
        {
            return name;
        }
    }
}
