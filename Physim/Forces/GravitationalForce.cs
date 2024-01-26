using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Forces
{
    public class GravitationalForce : Force
    {
        public float Gravitation { get; set; } = 9.81f;


        public override Vector3D GetNewton(SimulationUpdateStepInfo info, PhysicsObject obj)
        {
            
            return new Vector3D(0, - obj.Mass * Gravitation, 0);
        }

    }
}
