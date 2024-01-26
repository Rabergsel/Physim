using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim
{
    public class Athmosphere
    {
        public float BaseDensity { get; set; } = 1.015f;

        public virtual float GetPressure(Vector3D Position)
        {
            return 0f;
        }

        public float GetDensity(Vector3D Position)
        {
            return GetPressure(Position) * BaseDensity;
        }

    }
}
