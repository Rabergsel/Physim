﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Objects
{
    public class Cube : PhysicsObject
    {
        public Cube()
        {
            Name = "Cube";
        }

        public Cube(float Size)
        {
            Name = $"Cube_{Size}x{Size}x{Size}";
            this.Size = Size;
        }

        public float Size { get; set; } = 0;
        public override Vector3D getProjectedArea()
        {
            return new Vector3D(Size * Size, Size * Size, Size * Size);
        }

        public override Vector3D getAirResistanceCoefficient()
        {
            return new Vector3D(1.15f, 1.15f, 1.15f);
        }

        public override float Volume()
        {
            return Size * Size * Size;
        }

    }
}
