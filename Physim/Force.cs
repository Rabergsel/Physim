using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim
{
    public class Force
    {
        public string Name { get; set; } = "Force";

        public virtual Vector3D GetNewton()
        {
            return new Vector3D(Fx, Fy, Fz);
        }

        private float Newton { get; set; } = 0;

        public Vector3D Orientation { get; set; } = new Vector3D(0, 0, 0);


        public float Fx
        {
            get
            {
                return (float)Math.Cos(Orientation.X) * Newton;
            }
            set
            {

            }
        }

        public float Fy
        {
            get
            {
                return (float)Math.Cos(Orientation.Y) * Newton;
            }
            set
            {
                
            }
        }

        public float Fz
        {
            get
            {
                return (float)Math.Cos(Orientation.Z) * Newton;
            }
            set
            {

            }
        }

    }
}
