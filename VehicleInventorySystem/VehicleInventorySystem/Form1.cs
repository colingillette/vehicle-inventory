using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleInventorySystem
{
    public partial class Form1 : Form
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void deleteVehicle(string year, string make, string model, string vin)
        {
            int index = -1;

            foreach (Vehicle v in vehicles)
            {
                if (v.Year == year && v.Make == make && v.Model == model && v.Vin == vin)
                {
                    index = (v.Id - 1);
                }
            }

            if (index != -1)
            {
                vehicles.RemoveAt(index);
            }

            int i = 1;

            foreach (Vehicle v in vehicles)
            {
                v.Id = i;
                i++;
                MessageBox.Show(v.ShowInfo());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int id;
                string display = "Vehcile Added: ";

                mileageTextBox.Clear();

                id = (vehicles.Count + 1);

                Vehicle v = new Vehicle(id, yearTextBox.Text, makeTextBox.Text, modelTextBox.Text, vinTextBox.Text);

                vehicles.Add(v);

                display += v.ShowInfo();

                MessageBox.Show(display);
            }
            else
            {
                int id, mileage;
                string display = "Vehcile Added: ";

                id = (vehicles.Count + 1);
                int.TryParse(mileageTextBox.Text, out mileage);

                Vehicle v = new Vehicle(id, yearTextBox.Text, makeTextBox.Text, modelTextBox.Text, vinTextBox.Text, mileage);

                vehicles.Add(v);

                display += v.ShowInfo();

                MessageBox.Show(display);
            }

            yearTextBox.Clear();
            makeTextBox.Clear();
            modelTextBox.Clear();
            mileageTextBox.Clear();
            vinTextBox.Clear();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            string display = $"Our inventory has the following vehicles:\n";

            for (int i = 0; i < vehicles.Count(); i++)
            {
                display += $"{vehicles[i].ShowInfo()}\n";
            }

            MessageBox.Show(display);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string year, make, model, vin;

            year = yearTextBox.Text;
            make = makeTextBox.Text;
            model = modelTextBox.Text;
            vin = vinTextBox.Text;

            deleteVehicle(year, make, model, vin);
        }
    }
}
