package cz.restauracev2;

import java.util.ArrayList;
import java.util.List;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.event.EventListener;
import org.springframework.core.convert.ConversionService;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.service.CarService;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.PersonService;

@Configuration
public class InitialData {
	
	@Autowired
	private CarService carService;
	@Autowired
	private PersonService personService;
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	ConversionService conversionService;
	
	@EventListener(ApplicationReadyEvent.class)
	@Transactional
	public void afterStartUp() {
		//addInitialData();
	}
	
	public void addInitialData() {
		List<Car> cars = new ArrayList<>();		
		cars.add(new Car("Ford Fiesta Mk7", "3T60454", 25415));
		cars.add(new Car("Kia Ceed SW 1.6", "2T41864", 73485));		
		for(Car car : cars) {
			carService.insert(car);
		}
	
		List<Employee> employees = new ArrayList<>();	
		employees.add(new Employee("Vaclav Prochazka", "vaclav.prochazka@gmail.com", "vac", "pass", true, 25000));
		employees.add(new Employee("Karolina Mastna", "kam44@gmail.com", "kam44", "heslo", true, 26500));
		employees.add(new Employee("Prokop Buben", "fefev@email.cz", "prokfefev", "SloziteHeslo@!", true, 20000));
		employees.add(new Employee("Ursula Dobra", "dobraursula@seznam.cz", "dobraursula", "1234pass", true, 23150));
		employees.add(new Employee("Radoslav Kozeny", "rdslvkzn@gmail.com", "name66", "nzkvlsdr", true, 24000));
		employees.add(new Employee("Klara Horakova", "messpr@gmail.com", "mess33pr", "Xsr4QweP!41.", true, 25000));	
		for(Employee employee : employees) {
			personService.insert(employee);
		}
		
		List<Customer> customers = new ArrayList<>();	
		customers.add(new Customer("Jan Novak", "jannovak2264@volny.cz", "janxnovak", "mrprop41", true, "22 Bendova Ostrava-Radvanice"));
		customers.add(new Customer("Petra Novotna", "novpetra@seznam.cz", "petran664", "123456789", true, "12 Hradecka Ostrava-Svinov"));
		customers.add(new Customer("Pavel Omacka", "jfdr5@gmail.com", "jfdr5", "osmdesatdevet", true, "125 Karvinska Orlova"));
		customers.add(new Customer("Jiri Blecha", "blecha.jiri@gmail.com", "jiribl", "AsDfFdSa", true, "442 Nad Porubkou Ostrava-Poruba"));
		customers.add(new Customer("Patrik Nimrod", "spidervv@atlas.cz", "ressx1", "patrik71.", true, "123 Orlovska Petrvald"));
		customers.add(new Customer("Kvetoslava Homolkova", "kvethom@gmail.com", "kvethom", "OVAK888", true, "54 Palickova Ostrava-Nova Ves"));
		customers.add(new Customer("Zuzana Svobodova", "jir98@seznam.cz", "98jir", "123zuzana", true, "777 Sionkova Ostrava-Slezska Ostrava"));
		customers.add(new Customer("Antonin Cerny", "tonysww@seznam.cz", "tonda", "password1!", true, "126 Pomezni Vratimov"));
		customers.add(new Customer("Premysl Vesely", "orapr00@gmail.com", "orapr00", "hesloheslo", false, "145 U statku Ostrava-Bartovice"));
		customers.add(new Customer("Dusan Hala", "matgen@gmail.com", "halam", "gen741", false, "256 U sterkovny Hlucin"));
		for(Customer customer : customers) {
			personService.insert(customer);
		}
		
		List<Delivery> deliveries = new ArrayList<>();
		deliveries.add(new Delivery(employees.get(1), customers.get(4), cars.get(1), 159));
		deliveries.add(new Delivery(employees.get(0), customers.get(5), cars.get(1), 249));
		deliveries.add(new Delivery(employees.get(4), customers.get(9), cars.get(1), 115));
		deliveries.add(new Delivery(employees.get(2), customers.get(3), cars.get(1), 179));
		deliveries.add(new Delivery(employees.get(5), customers.get(0), cars.get(1), 219));
		deliveries.add(new Delivery(employees.get(2), customers.get(1), cars.get(1), 301));
		deliveries.add(new Delivery(employees.get(5), customers.get(9), cars.get(1), 436));
		deliveries.add(new Delivery(employees.get(3), customers.get(6), cars.get(1), 139));
		deliveries.add(new Delivery(employees.get(4), customers.get(7), cars.get(1), 199));
		deliveries.add(new Delivery(employees.get(0), customers.get(2), cars.get(1), 254));
		deliveries.add(new Delivery(employees.get(1), customers.get(4), cars.get(0), 345));
		deliveries.add(new Delivery(employees.get(4), customers.get(0), cars.get(0), 159));
		deliveries.add(new Delivery(employees.get(3), customers.get(1), cars.get(0), 246));
		deliveries.add(new Delivery(employees.get(2), customers.get(3), cars.get(0), 259));
		deliveries.add(new Delivery(employees.get(5), customers.get(9), cars.get(0), 174));
		deliveries.add(new Delivery(employees.get(5), customers.get(8), cars.get(0), 516));
		deliveries.add(new Delivery(employees.get(1), customers.get(9), cars.get(0), 321));
		deliveries.add(new Delivery(employees.get(2), customers.get(5), cars.get(0), 159));
		deliveries.add(new Delivery(employees.get(1), customers.get(3), cars.get(0), 229));
		deliveries.add(new Delivery(employees.get(0), customers.get(1), cars.get(0), 206));
		for(Delivery delivery : deliveries) {
			deliveryService.insert(delivery);
		}
	}
	
}
