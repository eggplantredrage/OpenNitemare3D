using System;
namespace Nitemare3D
{
    public sealed class Vec2
    {
        public float X, Y;

        public const float PI = 3.14159265359f;
        public const float Deg2Rad = (PI / 180);
        public const float Rad2Deg = (180 / PI);


        public static Vec2 Up
        {
            get
            {
                return new Vec2(0, -1);
            }
        }

        public static bool linePoint(Vec2 start, Vec2 end, Vec2 point)
        {
            var px = point.X;
            var py = point.Y;
            var x1 = start.X;
            var x2 = end.X;
            var y1 = start.Y;
            var y2 = end.Y;
            // get distance from the point to the two ends of the line
            float d1 = Distance(new Vec2(px, py), new Vec2(x1, y1));
            float d2 = Distance(new Vec2(px, py), new Vec2(x2, y2));

            // get the length of the line
            float lineLen = Distance(start, end);

            // since floats are so minutely accurate, add
            // a little buffer zone that will give collision
            float buffer = 0.1f;    // higher # = less accurate

            // if the two distances are equal to the line's 
            // length, the point is on the line!
            // note we use the buffer here to give a range, 
            // rather than one #
            if (d1 + d2 >= lineLen - buffer && d1 + d2 <= lineLen + buffer)
            {
                return true;
            }
            return false;
        }


        public static Vec2 Down
        {
            get
            {
                return new Vec2(0, 1);
            }
        }

        public static Vec2 Left
        {
            get
            {
                return new Vec2(-1, 0);
            }
        }

        public static Vec2 Right
        {
            get
            {
                return new Vec2(1, 0);
            }
        }

        public Vec2()
        {
            this.X = 0;
            this.Y = 0;
        }

        public override bool Equals(object obj)
        {
            var vec = obj as Vec2;
            return (vec.X == X && vec.Y == Y);
        }


        public static Vec2 Zero()
        {
            return new Vec2();
        }

        public Vec2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vec2 Transform(Vec2 Point, float Angle)
        {
            return Transform(new Vec2(0, 0), Point, Angle);
        }

        public static Vec2 operator +(Vec2 A, Vec2 B)
        {
            return new Vec2(A.X + B.X, A.Y + B.Y);
        }

        public static Vec2 operator -(Vec2 A, Vec2 B)
        {
            return new Vec2(A.X - B.X, A.Y - B.Y);
        }

        public static Vec2 operator /(Vec2 A, Vec2 B)
        {
            return new Vec2(A.X / B.X, A.Y / B.Y);
        }

        public static Vec2 operator /(Vec2 A, float B)
        {
            return new Vec2(A.X / B, A.Y / B);
        }

        public static Vec2 operator +(Vec2 A, float B)
        {
            return new Vec2(A.X + B, A.Y + B);
        }

        public static Vec2 operator -(Vec2 A, float B)
        {
            return new Vec2(A.X - B, A.Y - B);
        }

        public static Vec2 operator *(Vec2 A, float B)
        {
            return new Vec2(A.X * B, A.Y * B);
        }

        public static Vec2 operator %(Vec2 A, float B)
        {
            return new Vec2(A.X % B, A.Y % B);
        }

        public static float LookAt(Vec2 me, Vec2 target)
        {
            var dir = target - me;

            var r = (float)Math.Atan2(dir.Y, dir.X);
            return (r * Rad2Deg) + 180;
        }

        public static Vec2 Transform(Vec2 Origin, Vec2 Point, float Angle)
        {
            float c = (float)Math.Cos(Angle);
            float s = (float)Math.Sin(Angle);

            return new Vec2(
                                Origin.X + c * Point.X - s * Point.Y,
                                Origin.Y + s * Point.X + c * Point.Y
            ) - Origin * 2;
        }

        public static float Magnitude(Vec2 A)
        {
            return (float)Math.Sqrt(A.X * A.X + A.Y * A.Y);
        }

        public Vec2 Normalize()
        {
            float length = Magnitude(this);
            return new Vec2(X / length, Y / length);
        }

        public static float Distance(Vec2 A, Vec2 B)
        {
            return (float)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        }

        public static Vec2 Cross(Vec2 lhs, Vec2 rhs)
        {
            return new Vec2(
                lhs.Y * 0 - 0 * rhs.Y,
                0 * rhs.X - lhs.X * 0);
        }



    }
}
