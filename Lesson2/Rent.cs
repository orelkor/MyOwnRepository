using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Rent
    {
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public Car car { get; private set; }

           public Rent(DateTime DateFrom, DateTime DateTo, Car car)
        {
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
            this.car = car;
        }
    }
}
