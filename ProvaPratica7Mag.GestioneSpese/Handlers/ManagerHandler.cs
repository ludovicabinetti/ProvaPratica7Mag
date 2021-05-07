using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Handlers
{
    class ManagerHandler :AbstractHandler
    {
        public override ApprovalLevel Handle(decimal amount)
        {
            if (amount > 0 && amount <= 400)
                return ApprovalLevel.Manager;
            else
                return base.Handle(amount);
        }
    }
}
