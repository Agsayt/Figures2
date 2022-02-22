using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class Square : Figure
    {

        private int squareSide;
        private float halfSide;

        public Square(int side, Vec2 vec)
        {
            pos = vec;
            SetSide(side);
        }

        public override void Draw(Graphics g)
        {
            var x0 = pos.x - halfSide;
            var y0 = pos.y - halfSide;

            Pen pen = Pens.Black;

            if (isSelected) pen = Pens.Green;

            g.DrawRectangle(pen, x0, y0, squareSide, squareSide);
        }

        public override bool IsInside(Vec2 vec)
        {
            var xmin = pos.x - halfSide;
            var xmax = pos.x + halfSide;
            var ymin = pos.y - halfSide;
            var ymax = pos.y + halfSide;

            if (vec.x < xmin || vec.y < ymin) return false;
            if (vec.x > xmax || vec.y > ymax) return false;

            return true;
        }

        public override float Sdf(Vec2 p)
        {
            var d = (p - pos).Abs() - halfSide;

            float innerD = Math.Min(Math.Max(d.x, d.y), 0.0f);
            float outerD = d.Max(0.0f).Length();

            return innerD + outerD;
        }

        public void SetSide(int side)
        {
            squareSide = side;
            halfSide = squareSide * 0.5f;
        }
    }
}
