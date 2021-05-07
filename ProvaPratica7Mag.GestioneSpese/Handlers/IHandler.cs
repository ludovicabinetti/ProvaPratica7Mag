using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Handlers
{
    // interfaccia che definisce la struttura di un handler
    interface IHandler
    {
        IHandler SetNext(IHandler handler);

        ApprovalLevel Handle(decimal amount);
    }
}
