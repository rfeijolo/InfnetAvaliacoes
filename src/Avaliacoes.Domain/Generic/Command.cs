using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Domain.Generic
{
    public interface Command
    {
        Message Validate();

        void Execute(Activity currentActivity);
    }
}
