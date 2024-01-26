using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Athmospheres.Natural
{
    public class IsothermicAthmosphere : Athmosphere
    {
        public float BasePressure = 1021.5f;

        public float BaseHeight = 0f;

        public float HeightScaleFactor = 8400;

        public override float GetPressure(Vector3D Position)
        {
            return BasePressure * (float)Math.Pow(Math.E, -(Position.Y - BaseHeight) / HeightScaleFactor);
        }

    }
}
