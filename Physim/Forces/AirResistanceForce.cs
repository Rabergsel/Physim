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
        public override Vector3D GetNewton(SimulationUpdateStepInfo info, PhysicsObject obj)
        {
            return new Vector3D(
                -calculateResistanceForce(obj.getAirResistanceCoefficient().X, obj.VelocityVector.X, obj.getProjectedArea().X, info.athmosphere.GetDensity(obj.PositionVector)),
                -calculateResistanceForce(obj.getAirResistanceCoefficient().Y, obj.VelocityVector.Y, obj.getProjectedArea().Y, info.athmosphere.GetDensity(obj.PositionVector)),
                -calculateResistanceForce(obj.getAirResistanceCoefficient().Z, obj.VelocityVector.Z, obj.getProjectedArea().Z, info.athmosphere.GetDensity(obj.PositionVector)));
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
