using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Objects
{
    internal class Cylinder : PhysicsObject
    {
        public float Radius { get; set; } = 1f;
        public float Height { get; set; } = 1f;

        public override Vector3D getProjectedArea()
        {
            return new Vector3D(Height * 2 * Radius, Height * 2 * Radius, Radius * Radius * 3.1415f);
        }

        public override Vector3D getAirResistanceCoefficient()
        {
            return new Vector3D(1.2f, 1.2f, 1.1f);
        }

    }
}
