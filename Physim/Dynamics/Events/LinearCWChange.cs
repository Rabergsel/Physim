using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Dynamics.Events
{
    internal class LinearCWChange : Event
    {
        Vector3D FinalCW = new Vector3D(0, 0, 0);
        private Vector3D StartCW = new Vector3D(0, 0, 0);
        private Vector3D delta = new Vector3D(0, 0, 0);

        public float Seconds = 1f;

        public override bool CheckForFire(SimulationUpdateStepInfo info, DynamicObject obj)
        {
            return base.CheckForFire(info, obj);
        }

        public override DynamicObject FireEvent(SimulationUpdateStepInfo info, DynamicObject obj)
        {
            Fired = true;
            StartCW = obj.cwValues;
            delta = (FinalCW - StartCW) / Seconds;

            return obj;

        }

        public override DynamicObject Update(SimulationUpdateStepInfo info, DynamicObject obj)
        {
            obj.cwValues += delta * info.DeltaT;
            return obj;
        }

    }
}
