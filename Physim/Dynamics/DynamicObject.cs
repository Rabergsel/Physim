using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Dynamics
{
    public class DynamicObject : PhysicsObject
    {
        public Vector3D cwValues { get; set; } = new Vector3D(0, 0, 0);
        public Vector3D projectedAreas { get; set; } = new Vector3D(0, 0, 0);

        public List<Event> Events { get; set; } = new List<Event>();

        public DynamicObject()
        {
            this.Name = "DynamicObject";
        }
        public DynamicObject(string Name)
        {
            this.Name = Name;
        }


        public void FireEventByName(string name, SimulationUpdateStepInfo info)
        {
            for(int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Name == name) reassignValues(Events[i].FireEvent(info, (DynamicObject)MemberwiseClone()));
                
            }
        }

        public override Vector3D getAirResistanceCoefficient()
        {
            return cwValues;
        }

        public override Vector3D getProjectedArea()
        {
            return projectedAreas;
        }

        private void reassignValues(DynamicObject tocopy)
        {
            cwValues = tocopy.cwValues;
            projectedAreas = tocopy.projectedAreas;
        }

        public override void Update(SimulationUpdateStepInfo info)
        {

            foreach(var ev in Events)
            {
                if(!ev.Fired)
                {
                   
                    bool fire = ev.CheckForFire(info, (DynamicObject)MemberwiseClone());
                    if (fire) reassignValues(ev.FireEvent(info, (DynamicObject)MemberwiseClone()));
                }
                else
                {
                    reassignValues(ev.Update(info, (DynamicObject)MemberwiseClone()));
                }
            }

            ResultForce = new Vector3D(0, 0, 0);
            foreach (var force in Forces)
            {
                ResultForce += force.GetNewton(info, this);
            }

            Console.WriteLine($" t = {info.Time}\tF={ResultForce.ToString()}\t p = {PositionVector.ToString()}\tv = {VelocityVector.ToString()}\ta = {AccelerationVector.ToString()}");

            VelocityVector += AccelerationVector * info.DeltaT;
            PositionVector += VelocityVector * info.DeltaT;


        }

        

    }
}
