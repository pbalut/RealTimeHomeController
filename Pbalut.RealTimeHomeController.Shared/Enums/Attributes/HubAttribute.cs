using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Attributes
{
    public class HubAttribute : Attribute
    {
        public string Name { get; }

        public HubAttribute(string name)
        {
            Name = name;
        }
    }
}
