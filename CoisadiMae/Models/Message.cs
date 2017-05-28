using System;
using CoisadiMae.Models.Enums;

namespace CoisadiMae.Models
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public EnumOwner Owner { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}