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
        List<Rent> listRent = new List<Rent>();
        List<Car> cars = new List<Car>();

        public void makeRent(Rent rent)
        {
            listRent.Add(rent);
            db.SaveToDatabase(listRent.ToArray());

        }

        public List<Car> getAvailableCars(DateTime TimeFrom, DateTime TimeTo)
        {
            List<Car> availableCars = new List<Car>();
            
            if (db.GetFromDatabase<Rent>().Length != 0)
            {
                listRent = db.GetFromDatabase<Rent>().ToList(); // проблема с получением из бд
                cars = db.GetFromDatabase<Car>().ToList();

                foreach (var itemCar in cars)
                {
                    int k = 0;
                    
                    foreach (Rent itemRent in listRent)
                    {
                        if (itemRent.car.ToString() == itemCar.ToString())
                        {
                            if (TimeFrom > itemRent.DateFrom && TimeTo < itemRent.DateTo) k++;
                        }
                        else availableCars.Add(itemCar);
                    }

                    

                    
                }


                
            }
            else availableCars.AddRange(db.GetFromDatabase<Car>());
            return availableCars;
        }
    }
}
