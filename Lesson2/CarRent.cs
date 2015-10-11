using System.Windows.Forms;

namespace Lesson2
{
	public partial class CarRent : Form
	{
		public CarRent()
		{
			InitializeComponent();
            
        }
        
        CarService carService = new CarService();
        FileDatabase db = new FileDatabase(@"C:\AutoBase\");


        private void CarRent_Load(object sender, System.EventArgs e)
        {
            Car[] cars = new Car[]
                 {
                     new Car("Мазда","35-35-35","красный"),
                     new Car("Ауди", "32-35-32","зеленый"),
                     new Car("Рено", "33-33-33","синий"),
                     new Car("Опель", "34-35-36","красный"),
                     new Car("Лада", "7-77-77","красный")

                 };

            
            db.SaveToDatabase(cars);
            CarList.Items.AddRange(db.GetFromDatabase<Car>());
        }

        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CarDescription.Text = carService.getInfo((Car)CarList.SelectedItem);
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {
            
            if (carService.controlDate(dateTimePicker1.Value, dateTimePicker2.Value) == false) MessageBox.Show("Неверно введена дата.");
            else
            {
                Rent rent = new Rent(dateTimePicker1.Value, dateTimePicker2.Value, (Car)CarList.SelectedItem);

                if (carService.isCarAvailabele(rent))
                {
                    carService.makeRent(rent);
                    MessageBox.Show("Аренда выполнена успешно.");
                }
                else MessageBox.Show("Машина занята на данный период. Аренда невозможна.");
            }
        }
    }
}
