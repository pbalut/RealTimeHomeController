using Microsoft.AspNet.SignalR.Client;

namespace Pbalut.Uwp.Commons.Exceptions.SignalR
{
    public class InvalidHubConnectionStateException : HubBaseException
    {
        public ConnectionState State { get; private set; }

        public InvalidHubConnectionStateException(string endpoint, ConnectionState state)
            : base(endpoint)
        {
            State = state;
        }
    }
}
