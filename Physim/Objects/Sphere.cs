using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Objects
{
    public class Sphere : PhysicsObject
    {
        public float Radius { get; set; } = 1f;

        public override Vector3D getProjectedArea()
        {
            return new Vector3D(Radius * Radius * 3.1415f, Radius * Radius * 3.1415f, Radius * Radius * 3.1415f);
        }

        public override Vector3D getAirResistanceCoefficient()
        {
            return new Vector3D(0.15f, 0.15f, 0.15f);
        }
    }
}
