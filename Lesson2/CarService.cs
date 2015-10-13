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

        public Car[] getAllCars(Car[] cars)
        {
            cars = db.GetFromDatabase<Car>();
            return cars;
        }

        public List<Car> getAvailableCars(DateTime TimeFrom, DateTime TimeTo) // логика
        {
            List<Car> availableCars = new List<Car>();
            
            if (db.GetFromDatabase<Rent>().Length != 0)
            {
               
                listRent = db.GetFromDatabase<Rent>().ToList();
                cars = db.GetFromDatabase<Car>().ToList();

                foreach (var itemCar in cars)
                {
                    int k = 0;
                    int j = 0;
                    foreach (Rent itemRent in listRent)
                    {
                        if (itemRent.car.ToString() == itemCar.ToString())
                        {
                            if (((itemRent.DateTo > TimeTo && TimeTo > itemRent.DateFrom) || (itemRent.DateTo > TimeFrom && TimeFrom > itemRent.DateFrom))) j++;
                            
                        }
                        else k++;
                        
                        
                    }

                    if (k == listRent.Count || j == 0) availableCars.Add(itemCar);

                    
                }


                
            }
            else availableCars.AddRange(db.GetFromDatabase<Car>());
            return availableCars;
        }
    }
}
