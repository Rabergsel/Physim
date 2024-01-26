using Physim;
using Physim.Simulation;
using Physim.Objects;
using Physim.Forces;
using Physim.Athmospheres.Natural;

SimulationEnvironment sim = new SimulationEnvironment();
sim.athmosphere = new IsothermicAthmosphere();

Cube cube = new Cube();
cube.Size = 0.01f;
cube.Mass = 1;
cube.PositionVector = new Vector3D(0, 100, 0);
cube.Forces.Add(new GravitationalForce());
cube.Forces.Add(new AirResistanceForce());

sim.PhysicsObjects.Add(cube);

sim.MaximalTime = 1;
sim.TimeStepSize = 0.11f;

var steps = sim.RunSimulation();

foreach(var step in steps)
{
    Console.WriteLine($"t = {step.Time}\t Vel Cube: ({step.Objects[0].VelocityVector.X}|{step.Objects[0].VelocityVector.Y}|{step.Objects[0].VelocityVector.Z})");
}
Console.ReadLine();