using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Exporter
{
    public class JSONExporter
    {

        public static string Export(List<Simulation.SimulationStepInfo> Infos, bool beautyNotation)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Serialize(Infos, new System.Text.Json.JsonSerializerOptions() { WriteIndented = beautyNotation });
            }
            catch
            {
                return "Error while Exporting";
            }
        }

        public static void Export(List<Simulation.SimulationStepInfo> Infos, bool beautyNotation, string FilePath)
        {
            File.WriteAllText(FilePath, Export(Infos, beautyNotation));
        }

    }
}
