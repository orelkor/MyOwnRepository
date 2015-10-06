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


    }
}
