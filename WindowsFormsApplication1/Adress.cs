using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManDelivery
{
    class Adress
    {
        private String street;
        private int number;

        public Adress(String street, int number)
        {
            this.street = street;
            this.number = number;
        }

        public override String ToString()
        {
            return street + " " + number.ToString();
        }

        public String toGoogleString()
        {
            return street + number.ToString() + ",Wroclaw";
        }
    }
}
