using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Attributes
{
    public class GroupAttribute : Attribute
    {
        public string Name { get; }

        public GroupAttribute(string name)
        {
            Name = name;
        }
    }
}
