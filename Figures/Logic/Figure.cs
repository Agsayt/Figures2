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

        /// <summary>
        /// Check if vec2 is inside the figure
        /// </summary>
        /// <param name="vec">Vector2</param>
        /// <returns>Bool result</returns>
        public abstract bool IsInside(Vec2 vec);

        /// <summary>
        /// Draw figure
        /// </summary>
        /// <param name="g">Graphics</param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// SDF for figure
        /// </summary>
        /// <param name="p">Vector2</param>
        /// <returns>??</returns>
        public abstract float Sdf(Vec2 p);


        override
        public String ToString()
        {
            return name;
        }
    }
}
