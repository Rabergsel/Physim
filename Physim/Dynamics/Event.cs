namespace Physim.Dynamics
{
    public class Event
    {
        public string Name { get; set; } = "Event";

        public bool Fired { get; set; } = false;
        private Simulation.SimulationUpdateStepInfo InfoWhenFired { get; set; } = new Simulation.SimulationUpdateStepInfo();

        public virtual DynamicObject FireEvent(Simulation.SimulationUpdateStepInfo info, DynamicObject obj)
        {
            Fired = true;
            return obj;
        }

        public virtual bool CheckForFire(Simulation.SimulationUpdateStepInfo info, DynamicObject obj)
        {
            return false;
        }

        public virtual DynamicObject Update(Simulation.SimulationUpdateStepInfo info, DynamicObject obj)
        {
            return obj;
        }


    }
}