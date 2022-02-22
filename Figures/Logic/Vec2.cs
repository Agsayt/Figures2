﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures2.Logic
{
    internal class Vec2
    {
        public float x;
        public float y;

        public Vec2() { }

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.x + b.x, a.y + b.y);

        public static Vec2 operator -(Vec2 a, Vec2 b) => new Vec2(a.x - b.x, a.y - b.y);

        public static Vec2 operator -(Vec2 a, float x) => new Vec2(a.x - x, a.y - x);

        public static Vec2 operator *(Vec2 a, float x) => new Vec2(a.x * x, a.y * x);
        public static Vec2 operator /(Vec2 a, float x) => new Vec2(a.x / x, a.y / x);

        public static Vec2 FromPolar(float angle)
        {
            var nx = (float)Math.Cos(angle);
            var ny = (float)Math.Sin(angle);

            return new Vec2(nx, ny);
        }

        public float Length() => (float)Math.Sqrt(x * x + y * y);

        public Vec2 Abs() => new Vec2(Math.Abs(this.x), Math.Abs(this.y));

        public Vec2 Max(float v) => new Vec2(Math.Max(this.x, v), Math.Max(this.y, v));

        public Vec2 Normalize() => new Vec2(x / Length(), y / Length());
    }
}
