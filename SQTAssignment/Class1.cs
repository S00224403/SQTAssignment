using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQTAssignment
{
    class InsuranceService
    {
        public double CalcPremium(int age, string location)
        {
            double premium;
            if (location == "rural")
            {
                if ((age >= 18) && (age < 30))
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
                else
                    premium = 0.0;
            }
            else if (location == "urban")
            {
                if ((age >= 18) && (age <= 35))
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
                else
                    premium = 0.0;
            }
            else
            {
                premium = 0.0;
            }

            DiscountService ds = new DiscountService();
            double discount = ds.GetDiscount();

            if (age >= 50)
                premium = premium * discount;

            return premium;
        }
    }

}
