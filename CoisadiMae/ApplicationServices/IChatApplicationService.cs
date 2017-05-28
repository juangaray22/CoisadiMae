using System.Threading.Tasks;
using CoisadiMae.Models;

namespace CoisadiMae.ApplicationServices
{
    public interface IChatApplicationService : IApplicationService<Conversation>
    {
        Task<ConversationResponse> DoConversation(string phrase);
        Task<ConversationResponse> FetchDataFromServer(string phrase);
    }
}