using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class SimulationStepInfo
    {
        public List<PhysicsObject> Objects = new List<PhysicsObject>();

        public float TimeStepSize = 0.1f;
        public float Time = 0f;
        public float TimeStep = 0f;
    }
}
