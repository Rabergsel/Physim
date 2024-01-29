using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Sensors
{
    public class Sensor
    {

        public float SendFrequency = 1f;
        internal float lastTime = 0f;
        public string Name { get; set; } = "";

        public bool send(float currentTime)
        {
            if ((currentTime - lastTime) > (1 / SendFrequency)) return true;
            return false;
        }


        public virtual float getValue(PhysicsObject obj, Simulation.SimulationUpdateStepInfo info)
        {
            return 0f;
            lastTime = info.Time;
        }

    }
}
