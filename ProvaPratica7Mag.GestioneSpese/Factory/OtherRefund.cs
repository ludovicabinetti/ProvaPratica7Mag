using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Factory
{
    class OtherRefund : IRefund
    {
        public decimal CalculateRefundAmount(decimal amount)
        {
            return (10 * amount) / 100;
        }
    }
}
