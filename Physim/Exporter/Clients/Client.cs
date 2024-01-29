using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physim.Exporter.Clients
{
    public class Client
    {
        public virtual void Send(string args, string data)
        {
            Console.WriteLine(data);
        }

        public virtual string Recieve()
        {
            return "";
        }

    }
}
