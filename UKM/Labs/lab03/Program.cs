using UKM1Project;

List<Person> persons = new List<Person>();
persons.Add(new Person("Jan", "Novak", new DateTime(2000, 4, 16), "welder", 185, 80, 'M', "Czech", "blue", "Bachelor's degree", "black", "yellow"));
persons.Add(new Person("John", "Smith", new DateTime(2001, 4, 16), "programmer", 180, 75, 'M', "Czech", "green", "Master's degree", "brown", "lime"));

Car car = new Car("3T54125", persons, 1337, new DateTime(2019, 12, 20), 4, false, 600, "Toyota", 450000, 250, 50, false);

Console.WriteLine("Car licence plate: " + car.licencePlate);
Console.WriteLine("Amount of passengers: " + persons.Count);
Console.WriteLine("Total Nr of passengers: " + persons.Count);

Land land = new Land(950, "English", 2, 180);
House house = new House("Ceskoslovenske armady 20, 710 00 Slezska Ostrava", land, persons, 155, 5, true);

Console.WriteLine("House address: " + house.address);
Console.WriteLine("Num of occupants: " + persons.Count);