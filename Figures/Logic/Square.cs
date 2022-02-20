using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Logic
{
    internal class Square : Figure
    {

        private int squareSide;
        private float halfSide;

        public Square(int side, float x, float y)
        {
            posX = x;
            posY = y;
            SetSide(side);
        }

        public override void Draw(Graphics g)
        {
            var x0 = posX - halfSide;
            var y0 = posY - halfSide;

            Pen pen = Pens.Black;

            if (isSelected) pen = Pens.Green;

            g.DrawRectangle(pen, x0, y0, squareSide, squareSide);
        }

        public override bool IsInside(float x, float y)
        {
            var xmin = posX - halfSide;
            var xmax = posX + halfSide;
            var ymin = posY - halfSide;
            var ymax = posY + halfSide;

            if (x < xmin || y < ymin) return false;
            if (x > xmax || y > ymax) return false;

            return true;
        }

        public void SetSide(int side)
        {
            squareSide = side;
            halfSide = squareSide * 0.5f;
        }
    }
}
