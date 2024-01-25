using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim
{


    public class OrientationsClass
    {
        //X Directions
        public static Vector3D X_Positive { get { return new Vector3D(0, 3.1415f / 2, 3.1415f / 2); } set { } }
        public static Vector3D X_Negative { get { return new Vector3D(-3.1415f , 3.1415f / 2, 3.1415f / 2); } set { } }

        //Y Directions
        public static Vector3D Y_Positive { get { return new Vector3D(3.1415f / 2, 0, 3.1415f / 2); } set { } }
        public static Vector3D Y_Negative { get { return new Vector3D(3.1415f / 2, -3.1415f, 3.1415f / 2); } set { } }

        //Z Directions
        public static Vector3D Z_Positive { get { return new Vector3D(3.1415f / 2, 3.1415f / 2, 0); } set { } }
        public static Vector3D Z_Negative { get { return new Vector3D(3.1415f / 2, 3.1415f / 2, 3.1415f); } set { } }
    }
}
