using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM1Project
{
    public class House
    {
        public string address { get; set; }
        public Land land { get; set; }
        public List<Person> occupants { get; set; }
        public int squareMeters { get; set; }
        public int roomsCount { get; set; }
        public bool hasBalcony { get; set; }

        public House(string address, Land land, List<Person> occupants, int squareMeters, int roomsCount, bool hasBalcony)
        {
            this.address = address;
            this.land = land;
            this.occupants = occupants;
            this.squareMeters = squareMeters;
            this.roomsCount = roomsCount;
            this.hasBalcony = hasBalcony;
        }
    }
}
