using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Criterias
{
    public class Criteria
    {

        public virtual bool isFullfilled(List<PhysicsObject> objects, Simulation.SimulationUpdateStepInfo info)
        {
            return false;
        }

    }
}
