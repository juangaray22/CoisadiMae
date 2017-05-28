using System.Threading.Tasks;
//using Plugin.Connectivity.Abstractions;

namespace CoisadiMae.Util.ConnectivityFunctions
{
    /// <summary>
    /// Connectivity functions.
    /// </summary>
    public class ConnectivityFunctions : IConnectivityFunctions
    {
        //readonly IConnectivity _connectivity;

        public ConnectivityFunctions()
        {
            //_connectivity = connectivity;
        }

        /// <summary>
        /// Ises the connected.
        /// </summary>
        /// <returns>The connected.</returns>
        public async Task<bool> IsConnected()
        {
            return true;
        }
    }
}