using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avaliacoes.Domain.Generic
{
    public class Message
    {
        public enum Status
        {
            Success,
            Failure
        }

        public Status CurrentStatus { get; set; }

        public String CurrentMessage { get; set; }

        public Message(String message, Status status)
        {
            this.CurrentMessage = message;
            this.CurrentStatus = status;
        }
    }
}
