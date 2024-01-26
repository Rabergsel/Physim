using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class SimulationStepInfo
    {
        public List<PhysicsObject> Objects { get; set; } = new List<PhysicsObject>();
        public Athmosphere athmosphere { get; set; } = new Athmosphere();


        public float TimeStepSize { get; set; } = 0.1f;
        public float Time { get; set; } = 0f;
        public float TimeStep { get; set; } = 0f;
    }
}
