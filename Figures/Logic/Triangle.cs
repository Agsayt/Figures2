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
        List<Vec2> trianglePoints;

        public Triangle(int side, Vec2 vec)
        {
            pos = vec;

            SetSide(side);
            trianglePoints = new List<Vec2>();

            var p1 = new Vec2(pos.x, pos.y - triangleSide / 2);
            var p2 = new Vec2(pos.x + triangleSide / 2, pos.y + triangleSide / 2);
            var p3 = new Vec2(pos.x - triangleSide / 2, pos.y + triangleSide / 2);

            trianglePoints.Add(p1);
            trianglePoints.Add(p2);
            trianglePoints.Add(p3);
        }

        

        public override void Draw(Graphics g)
        {
            trianglePoints.Clear();
            var p1 = new Vec2(pos.x, pos.y - triangleSide/2);
            var p2 = new Vec2(pos.x + triangleSide / 2, pos.y + triangleSide / 2);
            var p3 = new Vec2(pos.x - triangleSide / 2, pos.y + triangleSide / 2);

            trianglePoints.Add(p1);
            trianglePoints.Add(p2);
            trianglePoints.Add(p3);

            Pen pen = Pens.Black;

            if (isSelected) pen = Pens.Green;

            g.DrawLine(pen, new PointF(p1.x, p1.y), new PointF(p2.x,p2.y));
            g.DrawLine(pen, new PointF(p2.x, p2.y), new PointF(p3.x, p3.y));
            g.DrawLine(pen, new PointF(p3.x, p3.y), new PointF(p1.x, p3.y));
        }



        public override bool IsInside(Vec2 vec)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;
            var pt = new Vec2(vec.x, vec.y);


            d1 = sign(pt, trianglePoints[0], trianglePoints[1]);
            d2 = sign(pt, trianglePoints[1], trianglePoints[2]);
            d3 = sign(pt, trianglePoints[2], trianglePoints[0]);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        float sign(Vec2 p1, Vec2 p2, Vec2 p3)
        {
            return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
        }

        public static Vec2 GetCentroid(List<Vec2> poly)
        {
            float accumulatedArea = 0.0f;
            float centerX = 0.0f;
            float centerY = 0.0f;

            for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                float temp = poly[i].x * poly[j].y - poly[j].x * poly[i].y;
                accumulatedArea += temp;
                centerX += (poly[i].x + poly[j].x) * temp;
                centerY += (poly[i].y + poly[j].y) * temp;
            }

            if (Math.Abs(accumulatedArea) < 1E-7f)
                return new Vec2(0,0);

            accumulatedArea *= 3f;
            return new Vec2(centerX / accumulatedArea, centerY / accumulatedArea);
        }

        /// <summary>
        /// Set side for triangle
        /// </summary>
        /// <param name="side">Side length</param>
        public void SetSide(int side)
        {
            triangleSide = side;
        }

        
        public override float Sdf(Vec2 p)
        {
            p = pos - p;
            var k = Math.Sqrt(3);
            p.x = Math.Abs(p.x) - 1;
            p.y = (float)(p.y + 1 / k);
            if (p.x + k * p.y > 0) p = new Vec2((float)(p.x - k * p.y), (float)(-k * p.x - p.y)) / 2;
            p.x -= (p.x >= -2) ? p.x : -2;
            return -p.Length() * Math.Sign(p.y);
        }
    }
}
