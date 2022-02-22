using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class Ray
    {
        Vec2 org;
        Vec2 dir;

        public Ray(Vec2 org, Vec2 dir)
        {
            this.org = org;
            this.dir = dir;
        }

        public Vec2 PointAtDistance(float distance)
        {
            var point = org + dir * distance;
            return point;
        }
    }
}
