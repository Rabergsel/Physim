using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class SimulationUpdateStepInfo
    {
        public float DeltaT { get; set; } = 0.1f;
        public float Time { get; set; } = 0f;
        
        public Athmosphere athmosphere { get; set; } = new Athmosphere();
    }
}
