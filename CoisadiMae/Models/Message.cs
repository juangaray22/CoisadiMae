using System;
using CoisadiMae.Models.Enums;
using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Message : BaseEntity
    {
        [ForeignKey(typeof(Conversation))]
        public int ConversationId { get; set; }
        public string Text { get; set; }
        public EnumOwner Owner { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}