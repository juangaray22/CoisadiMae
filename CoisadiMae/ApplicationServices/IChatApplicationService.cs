using System.Threading.Tasks;
using CoisadiMae.Models;

namespace CoisadiMae.ApplicationServices
{
    public interface IChatApplicationService : IApplicationService<Conversation>
    {
        Task<string> DoConversation(string phrase);
        Task<string> FetchDataFromServer(string phrase);
    }
}