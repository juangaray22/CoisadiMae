using CoisadiMae.Models;
using Prism.Commands;
using Prism.Mvvm;
//using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using CoisadiMae.ApplicationServices;
using System.Threading.Tasks;
using CoisadiMae.Util.UIFunctions;

namespace CoisadiMae.ViewModels
{
    //[ImplementPropertyChanged]
    public class ChatPageViewModel : BindableBase
    {
        readonly IChatApplicationService _chatService;
        readonly IApplicationService<Conversation> _conversationService;
        readonly IDialogsFunction _dialogFunction;

        public string MessageText { get; set; }
        public Conversation Conversation { get; set; }
        public DelegateCommand SendMessageCmd { get; set; }

        public ChatPageViewModel(IChatApplicationService chatService,
                                 IApplicationService<Conversation> conversationService,
                                 IDialogsFunction dialogFunction)
        {
            _chatService = chatService;
            _conversationService = conversationService;
            _dialogFunction = dialogFunction;
            SendMessageCmd = new DelegateCommand(SendMessage);

            Welcome();
        }

        async Task Welcome()
        {
            if (Conversation != null)
                return;

            var ret = await _chatService.DoConversation("Ola");
            if (!string.IsNullOrEmpty(ret))
                await SetBotForConversation(ret);
        }

        async Task SetBotForConversation(string message)
        {
            Conversation = new Conversation()
            {
                Bot = new Bot { Name = "Ana Maria", Id = 1 },
                Messages = new List<Message>
                {
                    new Message(){ Text=message, Date=DateTimeOffset.Now, Owner= Models.Enums.EnumOwner.Bot}
                }
            };

            await _conversationService.AddAsync(Conversation);
            Conversation = (await _conversationService.GetAllAsync()).Last();
        }

        async Task SetMonForConversation(string momName, int momAge)
        {
            Conversation.Mom = new Mom() { FirstName = momName, Age = momAge };

            await _conversationService.AddAsync(Conversation);
            Conversation = await _conversationService.GetAsync(Conversation.Id);
        }

        Action SendMessage
        {
            get
            {
                return new Action(async () =>
                {
                    var ret = string.Empty;

                    if (!string.IsNullOrEmpty((MessageText)))
                        ret = await _chatService.DoConversation(MessageText);

                    if (!string.IsNullOrEmpty(ret))
                    {
                        if (Conversation.Messages == null || !Conversation.Messages.Any())
                        {
                            Conversation.Messages = new List<Message>
                            {
                                new Message() { Text = MessageText, Date = DateTimeOffset.Now, Owner = Models.Enums.EnumOwner.Mom },
                                new Message() { Text = ret, Date = DateTimeOffset.Now, Owner = Models.Enums.EnumOwner.Bot }
                            };

                            await _conversationService.AddAsync(Conversation);
                            Conversation = (await _conversationService.GetAllAsync()).Last();
                        }

                        MessageText = string.Empty;
                    }
                    else
                        _dialogFunction.ShowToast(Util.Enums.EnumToastType.Warning, "Erro ao enviar mensagem, por favor tente novamente");
                });
            }
        }
    }
}