using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManDelivery
{
    class Task
    {
        private Adress start;
        private Adress end;
        private double approachTime;
        private int serviceTime = 5;

        public Task(Adress start, Adress end, int distance)
        {
            this.start = start;
            this.end = end;
            this.approachTime = distance / 467;
        }

        public int getTime()
        {
            int time = (int)this.approachTime + this.serviceTime;
            return time;
        }
    }
}
