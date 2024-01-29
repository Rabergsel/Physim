using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class RealTimeSimulationEnvironment : SimulationEnvironment
    {
        public float WaitingTimeMS = 100;



        public override List<SimulationStepInfo> RunSimulation(bool logSteps = true)
        {
            int TimeStep = 0;
            List<SimulationStepInfo> infos = new List<SimulationStepInfo>();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            float secs = 0f;
            while ((stopwatch.ElapsedMilliseconds / 1000) <  MaximalTime)
            {
                Time = stopwatch.ElapsedMilliseconds / 1000f;

                var UpdateInfo = new SimulationUpdateStepInfo()
                {
                    Time = Time,
                    DeltaT = WaitingTimeMS/1000,
                    athmosphere = athmosphere
                };

                foreach (var Object in DynamicsObjects)
                {
                    Object.Update(UpdateInfo);
                }

                foreach (var Object in PhysicsObjects)
                {
                    Object.Update(UpdateInfo);
                }

                var StepInfo = new SimulationStepInfo()
                {
                    Time = Time,
                    TimeStep = TimeStep,
                    TimeStepSize = Time - secs,

                };
                StepInfo.athmosphere = athmosphere;

                foreach (var obj in PhysicsObjects)
                {
                    StepInfo.Objects.Add(obj.GetClone());
                }

                infos.Add(StepInfo);

               secs = stopwatch.ElapsedMilliseconds / 1000;

                if (isEndCriteriaMet(UpdateInfo)) break;

                System.Threading.Thread.Sleep((int)WaitingTimeMS);

            }

            return infos;
        }

    }
}
