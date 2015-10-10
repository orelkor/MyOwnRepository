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
        Rent[] rents = new Rent[9999];
        int Count = 0;

        public void makeRent(Rent rent)
        {
            try
            {
                Count = int.Parse(System.IO.File.ReadAllText(@"C:\AutoBase\Count.txt"));
            }

            catch (Exception)
            {

            }
            rents[Count] = rent;
            db.SaveToDatabase(rents);
            Count++;
            System.IO.File.WriteAllText(@"C:\AutoBase\Count.fdb", Count.ToString());

        }

        public bool getAvailableCar(Rent rent)
        {
             
            int j = 0;

            foreach (Rent item in rents)
            {


                if (item != null)
                {
                    if ((item.car.ToString() != rent.car.ToString())) j=j;
                    else if (((item.DateFrom > rent.DateFrom && item.DateFrom > rent.DateTo) || (item.DateTo < rent.DateFrom && item.DateTo < rent.DateTo)) == false) j++;
                }
            }

            if (j > 0) return false;
            else return true;

       }

        public string getInfo(Car car)
        {
            return string.Format("Марка: {0}\nЦвет: {1}\nНомер: {2}", car.CarName, car.CarColor, car.CarNumber);
        }

        public bool controlDate(DateTime dt1,DateTime dt2)
        {
            if (dt1 > dt2 || dt1 < DateTime.Now) return false;
            else return true;
        }


    }
}
