using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Factory
{
    class FoodRefund : IRefund
    {
        public decimal CalculateRefundAmount(decimal amount)
        {
            return (70 * amount) / 100;
        }
    }
}
