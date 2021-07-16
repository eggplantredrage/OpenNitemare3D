namespace Nitemare3D
{
    public class Vec2i
    {
        public int X, Y;
        
        public Vec2i()
        {

        }

        public Vec2i(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override bool Equals(object obj)
        {
            var vec = obj as Vec2i;
            return (vec.X == X && vec.Y == Y);
        }


        public static Vec2i Zero()
        {
            return new Vec2i();
        }

        public static Vec2i operator +(Vec2i A, Vec2i B)
        {
            return new Vec2i(A.X + B.X, A.Y + B.Y);
        }

        public static Vec2i operator -(Vec2i A, Vec2i B)
        {
            return new Vec2i(A.X - B.X, A.Y - B.Y);
        }

        public static Vec2i operator /(Vec2i A, Vec2i B)
        {
            return new Vec2i(A.X / B.X, A.Y / B.Y);
        }

        public static Vec2i operator /(Vec2i A, int B)
        {
            return new Vec2i(A.X / B, A.Y / B);
        }

        public static Vec2i operator +(Vec2i A, int B)
        {
            return new Vec2i(A.X + B, A.Y + B);
        }

        public static Vec2i operator -(Vec2i A, int B)
        {
            return new Vec2i(A.X - B, A.Y - B);
        }

        public static Vec2i operator *(Vec2i A, int B)
        {
            return new Vec2i(A.X * B, A.Y * B);
        }

        public static Vec2i operator %(Vec2i A, int B)
        {
            return new Vec2i(A.X % B, A.Y % B);
        }

        
    }
}