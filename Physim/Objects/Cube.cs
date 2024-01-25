using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Objects
{
    public class Cube : PhysicsObject
    {

        public float Size = 0;
        public override Vector3D getProjectedArea()
        {
            return new Vector3D(Size * Size, Size * Size, Size * Size);
        }

    }
}
