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

        private int indexDelete(string year, string make, string model, string vin)
        {
            int index = -1;

            for (int i = 0; i < vehicles.Count(); i++)
            {
                if (year == vehicles[i].Year && make == vehicles[i].Make && model == vehicles[i].Model && vin == vehicles[i].Vin)
                {
                    i = index;
                }
            }

            return index;
        }

        private void fixList(int index)
        {
            if (index != -1)
            {
                vehicles.Remove(vehicles[index]);

                for (int i = 0; i < vehicles.Count; i++)
                {
                    vehicles[i].Id = (i + 1);
                }

                MessageBox.Show("Sucessfully deleted.");
            }
            else
            {
                MessageBox.Show("Cannot find a vehicle taht matches your criteria to delete.");
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
            int index;

            year = yearTextBox.Text;
            make = makeTextBox.Text;
            model = modelTextBox.Text;
            vin = vinTextBox.Text;

            //TODO: UnBreak
            index = indexDelete(year, make, model, vin);
            fixList(index);
        }
    }
}
