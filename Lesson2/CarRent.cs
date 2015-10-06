﻿using System.Windows.Forms;

namespace Lesson2
{
	public partial class CarRent : Form
	{
		public CarRent()
		{
			InitializeComponent();
        }

        CarService cs = new CarService();

        private void CarRent_Load(object sender, System.EventArgs e)
        {
            //Car[] cars = new Car[]
            //     {
            //         new Car("Мазда","35-35-35","красный"),
            //         new Car("Ауди", "32-35-32","зеленый"),
            //         new Car("Рено", "33-33-33","синий"),
            //         new Car("Опель", "34-35-36","красный"),
            //         new Car("Лада", "7-77-77","красный")

            //     };

            
            
            FileDatabase db = new FileDatabase(@"C:\AutoBase\");
            
            CarList.Items.AddRange(db.GetFromDatabase<Car>());
        }

        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CarDescription.Text = cs.getInfo((Car)CarList.SelectedItem);
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {
            if (cs.controlDate(dateTimePicker1.Value, dateTimePicker2.Value) == false) MessageBox.Show("Неверно введена дата.");
            else
            {
                if (cs.getAvailableCar(new Rent(dateTimePicker1.Value, dateTimePicker2.Value, (Car)CarList.SelectedItem)) == true)
                {
                    cs.makeRent(new Rent(dateTimePicker1.Value, dateTimePicker2.Value, (Car)CarList.SelectedItem));
                    MessageBox.Show("Аренда выполнена успешно.");
                }
                else MessageBox.Show("Машина занята на данный период. Аренда невозможна.");
            }
        }
    }
}
