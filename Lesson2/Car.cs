using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Car
    {
        public string CarName { get; private set; }
        public string CarColor { get; private set; }
        public string CarNumber { get; private set; }

        public Car(string carname, string carnumber, string carcolor)
        {
            CarName = carname;
            CarColor = carcolor;
            CarNumber = carnumber;
        }

        public override string ToString()
        {
            return CarName.ToString();
        }

       
    }
}
