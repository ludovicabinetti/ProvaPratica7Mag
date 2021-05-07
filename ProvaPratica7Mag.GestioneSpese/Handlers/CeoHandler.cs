using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Handlers
{
    class CeoHandler : AbstractHandler
    {
        public override ApprovalLevel Handle(decimal amount)
        {
            if (amount > 1000 && amount <= 2500)
                return ApprovalLevel.CEO;
            else
                return base.Handle(amount);
        }
    }
}
