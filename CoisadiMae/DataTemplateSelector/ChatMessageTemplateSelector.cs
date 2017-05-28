using CoisadiMae.Models;
using CoisadiMae.Views;
using Xamarin.Forms;

namespace CoisadiMae.DataTemplateSelector
{
    public class ChatMessageTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public ChatMessageTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(ChatLeftMessageItemTemplate));
            this.outgoingDataTemplate = new DataTemplate(typeof(ChatRightMessageItemTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as Message;
            if (message == null)
                return null;
            
            return message.Owner == Models.Enums.EnumOwner.Bot ?
                          this.incomingDataTemplate : 
                          this.outgoingDataTemplate;
        }

        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;
    }
}