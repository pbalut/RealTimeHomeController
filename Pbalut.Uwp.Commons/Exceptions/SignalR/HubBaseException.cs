using System;

namespace Pbalut.Uwp.Commons.Exceptions.SignalR
{
    public class HubBaseException : Exception
    {
        public string EndPoint { get; private set; }

        protected HubBaseException(string endpoint)
        {
            EndPoint = endpoint;
        }
    }
}
