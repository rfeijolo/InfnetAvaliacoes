using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Domain.Generic
{
    public class Activity
    {
        public Activity(Command command)
        {
            _command = command;
        }

        private Command _command;

        public Message Initiate()
        {
            var message = _command.Validate();

            if (message.CurrentStatus == Message.Status.Success)
            {
                _command.Execute(this);
            }

            return message;
        }

    }
}
