using Physim;
using Physim.Simulation;
using Physim.Objects;
using Physim.Forces;
using Physim.Athmospheres.Natural;
using Physim.Dynamics;
using Physim.Dynamics.Events;
using Physim.Exporter.Clients.MQTT;



var sim = new RealTimeSimulationEnvironment();
sim.athmosphere = new IsothermicAthmosphere();

DynamicObject cube = new DynamicObject();
cube.Mass = 0.15f;
cube.PositionVector = new Vector3D(0, 600, 0);
cube.Forces.Add(new GravitationalForce());
cube.Forces.Add(new AirResistanceForce());

cube.cwValues = new Vector3D(0.15f, 0.15f, 0.15f);
cube.projectedAreas = new Vector3D(0.01f, 0.04f, 0.01f);

cube.Events.Add(new TimebasedLinearCWChange(new Vector3D(0.25f, 1.4f, 0.25f), 2.5f, 29f));

var mqtt = new MQTTClient();
await mqtt.connectViaTCP("MqttOptions.txt");

cube.Client = mqtt;
cube.Sensors.Add(new Physim.Sensors.AccelerationSensor('y'));


sim.PhysicsObjects.Add(cube);
sim.MaximalTime = 1000;
sim.TimeStepSize = 0.05f;

sim.WaitingTimeMS = 10;

sim.EndCriterias.Add(new Physim.Criterias.BelowCoordinatesCriteria(new Vector3D(-10, 0, -10)));

var steps = sim.RunSimulation(false);

foreach(var step in steps)
{
   // Console.WriteLine($"t = {step.Time}\t Vel Cube: ({step.Objects[0].VelocityVector.X}|{step.Objects[0].VelocityVector.Y}|{step.Objects[0].VelocityVector.Z})");
}

Physim.Exporter.CSVExporter.Export(steps, "./", false);

Console.ReadLine();