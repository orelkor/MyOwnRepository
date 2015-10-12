using System.Windows.Forms;

namespace Lesson2
{
	public partial class CarRent : Form
	{
		public CarRent()
		{
			InitializeComponent();
            
        }
        
        Car car;
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


            carService.getAllCars(cars);
            CarList.Items.AddRange(carService.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value).ToArray());
        }
        
        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            car = (Car)CarList.SelectedItem;
            if (car != null)
            {
                CarDescription.Text = car.getInfo();
            }
            
        }

        private void MakeAnOrderButton_Click(object sender, System.EventArgs e)
        {

            if (Controles.controlDate(dateTimePicker1.Value, dateTimePicker2.Value) == false) MessageBox.Show("Неверно введена дата.");
            else
            {
                Rent rent = new Rent(dateTimePicker1.Value, dateTimePicker2.Value, (Car)CarList.SelectedItem);

                carService.makeRent(rent);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            CarList.Items.Clear();
            foreach (var item in carService.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value))
            {
                CarList.Items.Add(item);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {
            CarList.Items.Clear();
            foreach (var item in carService.getAvailableCars(dateTimePicker1.Value, dateTimePicker2.Value))
            {
                CarList.Items.Add(item);
            }
        }
    }
}
