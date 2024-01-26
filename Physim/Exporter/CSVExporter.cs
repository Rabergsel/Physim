using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Exporter
{
    public class CSVExporterOptions
    {
        public bool exportAthmosphereEnvironment = true;
    }

    public class CSVExporter
    {
        public static void Export(List<Simulation.SimulationStepInfo> Infos,string FolderPath, bool logProgress, bool replaceFiles = true, CSVExporterOptions options = null)
        {
            if(options == null) options = new CSVExporterOptions();

            string header = "time;a;v;a_X;a_Y;a_Z;v_X;v_Y;v_Z;X;Y;Z;";

            if (options.exportAthmosphereEnvironment) header += "p;rho;";

            if (logProgress) Console.WriteLine("Generating Output Files...");
            foreach (var info in Infos)
            {
                foreach (var obj in info.Objects)
                {
                    if (!File.Exists(obj.Name + ".csv")) File.WriteAllText(obj.Name + ".csv", header + "\n");
                    if (replaceFiles & File.Exists(obj.Name + ".csv")) File.WriteAllText(obj.Name + ".csv", header + "\n");
                }
            }

            if (logProgress) Console.WriteLine("Start exporting...");
            foreach (var info in Infos)
            {
                foreach(var obj in info.Objects)
                {
                    File.AppendAllText(obj.Name + ".csv", $"{info.Time};" +
                        $"{obj.AccelerationVector.Length};{obj.VelocityVector.Length};" +
                        $"{obj.AccelerationVector.X};{obj.AccelerationVector.Y};{obj.AccelerationVector.Z};" +
                        $"{obj.VelocityVector.X};{obj.VelocityVector.Y};{obj.VelocityVector.Z};" +
                        $"{obj.PositionVector.X};{obj.PositionVector.Y};{obj.PositionVector.Z};");

                    if(options.exportAthmosphereEnvironment)
                    {
                        File.AppendAllText(obj.Name + ".csv", $"{info.athmosphere.GetPressure(obj.PositionVector)};{info.athmosphere.GetDensity(obj.PositionVector)}");
                    }
                    File.AppendAllText(obj.Name + ".csv", "\n");
                }
                
                if (logProgress) Console.WriteLine($"Finsished Exporting t = {info.Time}");
            }

        }
    }
}
