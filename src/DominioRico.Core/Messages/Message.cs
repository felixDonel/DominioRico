using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioRico.Core.Messages
{
    public class Message
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }
        
        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
