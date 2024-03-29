﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Simulation
{
    public class SimulationEnvironment
    {
        public List<PhysicsObject> PhysicsObjects { get; set; } = new List<PhysicsObject>();
        public List<Dynamics.DynamicObject> DynamicsObjects { get; set; } = new List<Dynamics.DynamicObject>();
        public List<Criterias.Criteria> EndCriterias { get; set; } = new List<Criterias.Criteria>();
        public Athmosphere athmosphere { get; set; } = new Athmosphere();


        public float TimeStepSize = 0.1f;
        public float Time = 0;
        public float MaximalTime = 0;


        internal bool isEndCriteriaMet(SimulationUpdateStepInfo info)
        {

            foreach(var endcriteria in EndCriterias)
            {
                if (endcriteria.isFullfilled(PhysicsObjects, info)) return true;
            }

            return false;

        }
        

        public virtual List<SimulationStepInfo> RunSimulation(bool logSteps = true)
        {
            int TimeStep = 0;
            List<SimulationStepInfo> infos = new List<SimulationStepInfo>();

            for(Time = 0; Time < MaximalTime; Time+= TimeStepSize)
            {
                var UpdateInfo = new SimulationUpdateStepInfo()
                {
                    Time = Time,
                    DeltaT = TimeStepSize,
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
                    TimeStepSize = TimeStepSize,
                    
                };
                StepInfo.athmosphere = athmosphere;

                foreach(var obj in PhysicsObjects)
                {
                    StepInfo.Objects.Add(obj.GetClone());
                }

               if(logSteps) infos.Add(StepInfo);

                if (isEndCriteriaMet(UpdateInfo)) break;

            }

            return infos;
        }

    }
}
