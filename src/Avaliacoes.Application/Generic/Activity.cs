using Avaliacoes.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Application.Generic
{
    public class Activity
    {
        private ICommand _command;
        public Object Result { get; set; }

        public Activity(ICommand command)
        {
            _command = command;
        }

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
