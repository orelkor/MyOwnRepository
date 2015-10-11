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
        ListRent listRent = new ListRent();

        public void makeRent(Rent rent)
        {

            listRent.Add(rent);
            Rent[] rents = listRent.ToArray();
            db.SaveToDatabase(rents);
            

        }

        public bool isCarAvailabele(Rent rent)
        {
             
            int j = 0;

            if (db.GetFromDatabase<Rent>().Length > 0)
            {
                Rent[] res = db.GetFromDatabase<Rent>();
                foreach (var item in res)
                {
                    listRent.Add(item);
                }
            }

            foreach (Rent item in listRent)
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
