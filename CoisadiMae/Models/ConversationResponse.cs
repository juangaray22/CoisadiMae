using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoisadiMae.Models
{
    public class ConversationResponse
    {
        public List<Intent> intents { get; set; }
        public Input input { get; set; }
        public Output output { get; set; }
        public Context context { get; set; }
    }
}
