using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Criterias
{
    public class OverCoordinatesCriteria : Criteria
    {
        public Vector3D maximumCriteria { get; set; } = new Vector3D(0, 0, 0);

        public OverCoordinatesCriteria(Vector3D maximum)
        {
            maximumCriteria = maximum;
        }

        public override bool isFullfilled(List<PhysicsObject> objects, SimulationUpdateStepInfo info)
        {
            foreach(PhysicsObject physObject in objects)
            {
                if (physObject.PositionVector.X > maximumCriteria.X
                    || physObject.PositionVector.Y > maximumCriteria.Y
                    || physObject.PositionVector.Z > maximumCriteria.Z
                    )
                {
                    return true;
                }
            }
            return false;
        }


    }
}
