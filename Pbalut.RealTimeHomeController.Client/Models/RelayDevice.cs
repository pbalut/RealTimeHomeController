using System;

namespace Pbalut.RealTimeHomeController.Client.Models
{
    public class RelayDevice
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public Uri Icon { get; set; }
    }
}