using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM1Project
{
    public class Car
    {
        public string licencePlate { get; set; }
        public List<Person> passengers { get; set; }
        public int mileage { get; set; }
        public DateTime purchaseDate { get; set; }
        public int seats { get; set; }
        public bool isElectric { get; set; }
        public int trunkCapacity { get; set; }
        public string manufacturer { get; set; }
        public int price { get; set; }
        public int maxSpeed { get; set; }
        public int tankCapacity { get; set; }
        public bool hasWindshield { get; set; }

        public Car(string licencePlate, List<Person> passengers, int mileage, DateTime purchaseDate, int seats, bool isElectric, int trunkCapacity, string manufacturer, int price, int maxSpeed, int tankCapacity, bool hasWindshield)
        {
            this.licencePlate = licencePlate;
            this.passengers = passengers;
            this.mileage = mileage;
            this.purchaseDate = purchaseDate;
            this.seats = seats;
            this.isElectric = isElectric;
            this.trunkCapacity = trunkCapacity;
            this.manufacturer = manufacturer;
            this.price = price;
            this.maxSpeed = maxSpeed;
            this.tankCapacity = tankCapacity;
            this.hasWindshield = hasWindshield;
        }
    }
}
