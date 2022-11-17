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
import cz.restauracev2.service.CarService;

@RestController
public class CarRestController {

	@Autowired
	private CarService carService;
	
    @GetMapping("/api/cars")
    public List<Car> showCarList(){
    	return carService.findAll();
    }
    
    @PostMapping("/api/cars")
    ResponseEntity<String> addCar(@RequestBody Car car){
    	carService.insert(car);
        return ResponseEntity.status(HttpStatus.OK)
            .body("Auto bylo úspěšně přidáno.");
    }
    
    @PutMapping("/api/cars/{id}")
    ResponseEntity<String> updateCar(@RequestBody Car car, @PathVariable Long id){	
        Car existingCar = carService.findById(id);
        existingCar.setName(car.getName());
        existingCar.setLicencePlate(car.getLicencePlate());
        existingCar.setMileage(car.getMileage());
    	carService.update(existingCar);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Auto bylo úspěšně upraveno.");
    }
    
    @DeleteMapping("/api/cars/{id}")
    ResponseEntity<String> deleteCar(@PathVariable Long id){
    	Car car = carService.findById(id);
    	carService.delete(car);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Auto bylo úspěšně smazáno.");
    }
}
