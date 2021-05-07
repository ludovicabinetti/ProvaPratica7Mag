using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Handlers
{
    class OperationalManager : AbstractHandler
    {
        public override ApprovalLevel Handle(decimal amount)
        {
            if (amount > 400 && amount <= 1000)
                return ApprovalLevel.OperationalManager;
            else
                return base.Handle(amount);
        }
    }
}
