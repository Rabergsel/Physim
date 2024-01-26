using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Athmospheres.Simple
{
    public class IsobaricAthmosphere : Athmosphere
    {

        /// <summary>
        /// Pressure in milli-bar
        /// </summary>
        public float Pressure { get; set; } = 1015f;

        public override float GetPressure(Vector3D Position)
        {
            return Pressure;
        }

    }
}
