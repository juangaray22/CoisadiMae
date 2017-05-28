using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Conversation : BaseEntity
    {
        public Mom Mom { get; set; }


        public Bot Bot { get; set; }

        public List<Message> Messages { get; set; }
    }
}