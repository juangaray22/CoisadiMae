using System.Threading.Tasks;

namespace CoisadiMae.Util.ConnectivityFunctions
{
    /// <summary>
    /// Connectivity functions.
    /// </summary>
    public interface IConnectivityFunctions
    {
        Task<bool> IsConnected();
    }
}