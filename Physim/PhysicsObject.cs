namespace Physim
{
    public class PhysicsObject
    {
        public string Name { get; set; }

        public float Mass { get; set; } = 0;
        
        public List<Force> Forces { get; set; } = new List<Force>();

        public Vector3D ResultForce { get; set; } = new Vector3D(0, 0, 0);

        public virtual float Volume()
        {
            return 0f;
        }


        public virtual Vector3D getAirResistanceCoefficient()
        {
            return new Vector3D(0, 0, 0);
        }
        public virtual Vector3D getProjectedArea()
        {
            return new Vector3D(0, 0, 0);
        }

        public PhysicsObject GetClone()
        {
            return (PhysicsObject)this.MemberwiseClone();
        }

        //Dynamic Attributes
        public Vector3D PositionVector { get; set; } = new Vector3D(0, 0, 0);

        public Vector3D VelocityVector { get; private set; } = new Vector3D(0, 0, 0);

        public Vector3D AccelerationVector { get { return ResultForce / Mass; } set { } }

        public void Update(Simulation.SimulationUpdateStepInfo info)
        {
            ResultForce = new Vector3D(0, 0, 0);
            foreach(var force in Forces)
            {
                ResultForce += force.GetNewton(info, this);
            }

            Console.WriteLine("Resulting Force: " + ResultForce.ToString());

            VelocityVector += AccelerationVector * info.DeltaT;
            PositionVector += VelocityVector * info.DeltaT;
        }

        
        
        

    }
}