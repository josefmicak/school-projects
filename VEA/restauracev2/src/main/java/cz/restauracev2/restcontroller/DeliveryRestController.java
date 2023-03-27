package cz.restauracev2.restcontroller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.service.CarService;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.PersonService;

@RestController
public class DeliveryRestController {
	
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	private PersonService personService;
	@Autowired
	private CarService carService;

    @GetMapping("/api/deliveries")
    public List<Delivery> showDeliveryList(){
    	return deliveryService.findAll();
    }
    
    @PostMapping("/api/deliveries")
    ResponseEntity<String> addDelivery(@RequestBody Delivery delivery){
    	deliveryService.insert(delivery);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Objednávka byla úspěšně přidána.");
    }
    
    @PutMapping("/api/deliveries/{id}")
    ResponseEntity<String> updateDelivery(@RequestBody Delivery delivery, @PathVariable Long id){	
        Employee employee = (Employee) personService.findById(Long.valueOf(delivery.getEmployee().getId()));
        Customer customer = (Customer) personService.findById(Long.valueOf(delivery.getCustomer().getId()));
        Car car = carService.findById(Long.valueOf(delivery.getCar().getId()));
    	
        Delivery existingDelivery = deliveryService.findById(id);
        //existingDelivery.id = id;
        existingDelivery.setEmployee(employee);
        existingDelivery.setCustomer(customer);
        existingDelivery.setCar(car);
        //existingDelivery.creationDate = existingDeliveryCreationDate;
        existingDelivery.price = delivery.price;
        deliveryService.update(existingDelivery);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Objednávka byla úspěšně upravena.");
    }
    
    @DeleteMapping("/api/deliveries/{id}")
    ResponseEntity<String> deleteDelivery(@PathVariable Long id){
    	Delivery delivery = deliveryService.findById(id);
    	deliveryService.delete(delivery);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Objednávka byla úspěšně smazána.");
    }

}
