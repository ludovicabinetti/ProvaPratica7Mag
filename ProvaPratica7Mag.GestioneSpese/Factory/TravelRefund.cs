using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Factory
{
    class TravelRefund : IRefund
    {
        public decimal CalculateRefundAmount(decimal amount)
        {
            return amount + 50;
        }
    }
}
