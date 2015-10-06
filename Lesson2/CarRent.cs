using System.Windows.Forms;

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
            //db.SaveToDatabase(cars);
            CarList.Items.AddRange(db.GetFromDatabase<Car>());
        }

        private void CarList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CarDescription.Text = cs.getInfo((Car)CarList.SelectedItem);
        }
    }
}
