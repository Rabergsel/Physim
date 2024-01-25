using Physim;
using Physim.Simulation;
using Physim.Objects;

SimulationEnvironment sim = new SimulationEnvironment();

Cube cube = new Cube();
cube.Size = 1;
cube.Mass = 1;
cube.PositionVector = new Vector3D(0, 10, 0);
cube.Forces.Add(new Force(Physim.OrientationsClass.Y_Negative, 1));

sim.PhysicsObjects.Add(cube);

sim.MaximalTime = 10;
sim.TimeStepSize = 1;

var steps = sim.RunSimulation();

foreach(var step in steps)
{
    Console.WriteLine($"t = {step.Time}\t Pos Cube: ({step.Objects[0].PositionVector.X}|{step.Objects[0].PositionVector.Y}|{step.Objects[0].PositionVector.Z})");
}
Console.ReadLine();