using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class Circle : Figure
    {
        private int radius;
        private int squaredRadius;
        private int diameter;

        public Circle(Vec2 vec)
        {
            pos = vec;
            SetRadius(5);
        }

        public override bool IsInside(Vec2 vec)
        {
            var dx = vec.x - pos.x;
            var dy = vec.y - pos.y;

            if (dx * dx + dy * dy <= squaredRadius) return true;

            return false;
        }

        public override void Draw(Graphics g)
        {
            var x0 = pos.x - radius;
            var y0 = pos.y - radius;

            var rgb = color;
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(255, (int)rgb.red, (int)rgb.green, (int)rgb.blue)));

            if (isSelected) pen = Pens.Green;

            g.DrawEllipse(pen, x0, y0, diameter, diameter);
        }

        public void SetRadius(int r)
        {
            radius = r;
            squaredRadius = radius * radius;
            diameter = radius * 2;
        }

        public override float Sdf(Vec2 p)
        {
            return (pos - p).Length() - radius;
        }
    }
}
