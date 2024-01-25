using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class SimulationEnvironment
    {
        public List<PhysicsObject> PhysicsObjects { get; set; } = new List<PhysicsObject>();

        public float TimeStepSize = 0.1f;
        public float Time = 0;
        public float MaximalTime = 0;

        public List<SimulationStepInfo> RunSimulation(bool logSteps = true)
        {
            int TimeStep = 0;
            List<SimulationStepInfo> infos = new List<SimulationStepInfo>();

            for(Time = 0; Time < MaximalTime; Time+= TimeStepSize)
            {
                var UpdateInfo = new SimulationUpdateStepInfo()
                {
                    Time = Time,
                    DeltaT = TimeStepSize
                };

                foreach(var Object in PhysicsObjects)
                {
                    Object.Update(UpdateInfo);
                }

                infos.Add(new SimulationStepInfo()
                {
                    Objects = PhysicsObjects,
                    Time = Time,
                    TimeStep = TimeStep,
                    TimeStepSize = TimeStepSize
                });

            }

            return infos;
        }

    }
}
