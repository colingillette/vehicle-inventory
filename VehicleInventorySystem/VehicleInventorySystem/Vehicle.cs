using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventorySystem
{
    class Vehicle
    {
        private int _id;
        private string _year;
        private string _make;
        private string _model;
        private int _mileage;
        private string _vin;

        public Vehicle(int id, string year, string make, string model, string vin, int mileage)
        {
            if (mileage > 0)
            {
                _id = id;
                _year = year;
                _make = make;
                _model = model;
                _mileage = mileage;
                _vin = vin;
            }
        }

        public Vehicle(int id, string year, string make, string model, string vin)
        {
            _id = id;
            _year = year;
            _make = make;
            _model = model;
            _mileage = 0;
            _vin = vin;
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        public string Vin
        {
            get { return _vin; }
            set { _vin = value; }
        }

        public string ShowInfo()
        {
            string desc = $"#{Id}: {Year} {Make} {Model} has {Mileage} miles on it. Last four digits of VIN: {Vin}";
            return desc;
        }
    }
}