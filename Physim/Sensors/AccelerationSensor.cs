using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Sensors
{
    public class AccelerationSensor : Sensor
    {

        char axis = 'x';

        public AccelerationSensor(char axis = 'x')
        {
           
            this.axis = axis;
            Name = "acc_" + axis;
        }

        public override float getValue(PhysicsObject obj, SimulationUpdateStepInfo info)
        {
            lastTime = info.Time;

            switch (axis)
            {
                case 'x':
                    return obj.AccelerationVector.X;
                    break;
                case 'y':
                    return obj.AccelerationVector.Y;
                    break;
                case 'z':
                    return obj.AccelerationVector.Z;
                    break;
                default:
                    return 0;

            }
        }


    }
}
