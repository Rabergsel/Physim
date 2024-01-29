using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Criterias
{
    public class BelowCoordinatesCriteria : Criteria
    {
        public Vector3D minimumCoordinates { get; set; } = new Vector3D(0, 0, 0);

        public BelowCoordinatesCriteria(Vector3D minimum)
        {
            minimumCoordinates = minimum;
        }

        public override bool isFullfilled(List<PhysicsObject> objects, SimulationUpdateStepInfo info)
        {
            foreach(PhysicsObject physObject in objects)
            {
                if (physObject.PositionVector.X < minimumCoordinates.X
                    || physObject.PositionVector.Y < minimumCoordinates.Y
                    || physObject.PositionVector.Z < minimumCoordinates.Z
                    )
                {
                    return true;
                }
            }
            return false;
        }


    }
}
