using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Forces
{
    public class BuoyancyForce : Force
    {
        public override Vector3D GetNewton(SimulationUpdateStepInfo info, PhysicsObject obj)
        {
            Orientation = OrientationsClass.Y_Positive;
            return new Vector3D(0, info.athmosphere.GetDensity(obj.PositionVector) * obj.Volume(), 0);
        }
    }
}
