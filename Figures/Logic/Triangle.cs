using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class Triangle : Figure
    {
        private int triangleSide;
        List<PointF> trianglePoints;

        public Triangle(int side, Vec2 vec)
        {
            pos = vec;

            SetSide(side);
            trianglePoints = new List<PointF>();

            var p1 = new PointF(pos.x, pos.y - triangleSide / 2);
            var p2 = new PointF(pos.x + triangleSide / 2, pos.y + triangleSide / 2);
            var p3 = new PointF(pos.x - triangleSide / 2, pos.y + triangleSide / 2);

            trianglePoints.Add(p1);
            trianglePoints.Add(p2);
            trianglePoints.Add(p3);
        }

        

        public override void Draw(Graphics g)
        {
            trianglePoints.Clear();
            var p1 = new PointF(pos.x, pos.y - triangleSide/2);
            var p2 = new PointF(pos.x + triangleSide / 2, pos.y + triangleSide / 2);
            var p3 = new PointF(pos.x - triangleSide / 2, pos.y + triangleSide / 2);

            trianglePoints.Add(p1);
            trianglePoints.Add(p2);
            trianglePoints.Add(p3);

            Pen pen = Pens.Black;

            if (isSelected) pen = Pens.Green;

            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p1);
        }



        public override bool IsInside(Vec2 vec)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;
            var pt = new PointF(vec.x, vec.y);


            d1 = sign(pt, trianglePoints[0], trianglePoints[1]);
            d2 = sign(pt, trianglePoints[1], trianglePoints[2]);
            d3 = sign(pt, trianglePoints[2], trianglePoints[0]);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        float sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public static PointF GetCentroid(List<PointF> poly)
        {
            float accumulatedArea = 0.0f;
            float centerX = 0.0f;
            float centerY = 0.0f;

            for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                float temp = poly[i].X * poly[j].Y - poly[j].X * poly[i].Y;
                accumulatedArea += temp;
                centerX += (poly[i].X + poly[j].X) * temp;
                centerY += (poly[i].Y + poly[j].Y) * temp;
            }

            if (Math.Abs(accumulatedArea) < 1E-7f)
                return PointF.Empty;

            accumulatedArea *= 3f;
            return new PointF(centerX / accumulatedArea, centerY / accumulatedArea);
        }

        public void SetSide(int side)
        {
            triangleSide = side;
        }

        public override float Sdf(Vec2 p)
        {
            throw new NotImplementedException();
        }
    }
}
