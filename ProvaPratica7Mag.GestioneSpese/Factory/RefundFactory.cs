using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Factory
{
    class RefundFactory
    {
        public static decimal CalculateRefund(Category category, decimal amount)
        {
            if (category == Category.Travel)
                return new TravelRefund().CalculateRefundAmount(amount);
            else if (category == Category.Accomodation)
                return new AccomodationRefund().CalculateRefundAmount(amount);
            else if (category == Category.Food)
                return new FoodRefund().CalculateRefundAmount(amount);
            else if (category == Category.Other)
                return new OtherRefund().CalculateRefundAmount(amount);
            else
                return 0;
        }
    }
}
