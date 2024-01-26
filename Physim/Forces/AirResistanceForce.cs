using Physim.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Forces
{
    public class AirResistanceForce : Force
    {
        public AirResistanceForce()
        {
            this.Name = "Air Resistance Force";
        }
        public AirResistanceForce(string Name)
        {
            this.Name = Name;
        }

        public override Vector3D GetNewton(SimulationUpdateStepInfo info, PhysicsObject obj)
        {
            return new Vector3D(
               -Math.Sign(obj.VelocityVector.X) * calculateResistanceForce(obj.getAirResistanceCoefficient().X, obj.VelocityVector.X, obj.getProjectedArea().X, info.athmosphere.GetDensity(obj.PositionVector)),
               -Math.Sign(obj.VelocityVector.Y) * calculateResistanceForce(obj.getAirResistanceCoefficient().Y, obj.VelocityVector.Y, obj.getProjectedArea().Y, info.athmosphere.GetDensity(obj.PositionVector)),
               -Math.Sign(obj.VelocityVector.Z) * calculateResistanceForce(obj.getAirResistanceCoefficient().Z, obj.VelocityVector.Z, obj.getProjectedArea().Z, info.athmosphere.GetDensity(obj.PositionVector)));
        }

        private float calculateResistanceForce(float cw, float velocity, float area, float density)
        {
            var F = cw * area * density * velocity * velocity * 0.5f;
            //Console.WriteLine($"Air Resistance: F = {F}\t\t cw = {cw}\tv = {velocity}\tA={area}\trho = {density}");
            if (F == float.NaN) return 0;
            return F;
            
        }

    }
}
