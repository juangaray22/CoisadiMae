using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Conversation : BaseEntity
    {
        [ForeignKey(typeof(Mom))]
        public Mom Mom { get; set; }
        public int MomId { get; set; }

        [ForeignKey(typeof(Bot))]
        public Bot Bot { get; set; }
        public int BotId { get; set; }

        public List<Message> Messages { get; set; }
    }
}