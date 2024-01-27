using Physim.Simulation;

namespace Physim.Dynamics.Events
{
    public class TimebasedLinearCWChange : Event
    {
        public TimebasedLinearCWChange(Vector3D FinalCW, float Seconds, float FireTime)
        {
            this.FinalCW = FinalCW;
            this.Seconds = Seconds;
            this.FireTime = FireTime;
        }

        public Vector3D FinalCW = new Vector3D(0, 0, 0);
        private Vector3D StartCW = new Vector3D(0, 0, 0);
        private Vector3D delta = new Vector3D(0, 0, 0);


        public float FireTime = 10f;
        public float Seconds = 1f;

        public override bool CheckForFire(SimulationUpdateStepInfo info, DynamicObject obj)
        {
            return info.Time > FireTime;
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
