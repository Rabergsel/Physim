using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Sensors
{
    public class Sensor
    {
        public string Name { get; set; } = "";

        public virtual float getValue(PhysicsObject obj, Simulation.SimulationUpdateStepInfo info)
        {
            return 0f;
        }

    }
}
