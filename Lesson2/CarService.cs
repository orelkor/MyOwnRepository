using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class CarService
    {
        FileDatabase db = new FileDatabase(@"C:\AutoBase\");
        Rent[] rents = new Rent[999];
        int Count = 0;
        public void makeRent(Rent rent)
        {
            rents[Count] = rent;
            db.SaveToDatabase(rents);
        }

        public bool getAvailableCar(Rent rent)
        {
            Rent[] rents = new Rent[999];
            rents = db.GetFromDatabase<Rent>();
            int j = 0;
            for (int i = 0; i < 998; i++)
            {
                if (rents[i].car == rent.car && rents[i].DateFrom > rent.DateFrom && rents[i].DateTo < rent.DateTo) j++;
            }
            if (j > 0) return true;
            else return false;
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
