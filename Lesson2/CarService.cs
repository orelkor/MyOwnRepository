using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class CarService
    {
        public void makeRent(Rent rent)
        {
            
        }

        public void getAvailableCar(Rent rent)
        {
        
        }

        public string getInfo(Car car)
        {
            return String.Format("Марка: {0}\nЦвет: {1}\nНомер: {2}", car.CarName, car.CarColor, car.CarNumber);
        }

        public bool controlDate(DateTime dt1,DateTime dt2)
        {
            if (dt1 > dt2 || dt1 < DateTime.Now) return false;
            else return true;
        }


    }
}
