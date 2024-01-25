using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim
{
    public class Vector3D
    {
        public float X = 0;
        public float Y = 0;
        public float Z = 0;

        public double Length {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            set
            {

            }
        }

        public Vector3D(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public static Vector3D operator + (Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator - (Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator * (Vector3D a, float b)
        {
            return new Vector3D(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3D operator /(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }
        public static Vector3D operator /(Vector3D a, float b)
        {
            return new Vector3D(a.X / b, a.Y / b, a.Z / b);
        }
        public static Vector3D operator /(Vector3D a, int b)
        {
            return new Vector3D(a.X / b, a.Y / b, a.Z / b);
        }

    }
}
