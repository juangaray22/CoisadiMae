using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace CoisadiMae.Models
{
   public  class Mom : BaseEntity
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        [Ignore]
        public string FormattedName => $"{FirstName} {LastName}";

        public List<Simulation> Simulations { get; set; }

        public List<Son> Sons { get; set; }


    }
}