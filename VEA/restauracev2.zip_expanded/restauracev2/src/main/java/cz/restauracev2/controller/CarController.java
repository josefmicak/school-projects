package cz.restauracev2.controller;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.service.CarService;
import cz.restauracev2.service.DeliveryService;

@Controller
public class CarController {	
	
	@Autowired
	private CarService carService;
	@Autowired
	private DeliveryService deliveryService;
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/cars")
    public String showCarsList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("cars", carService.findAll());
    	model.addAttribute("message", message);
        return "cars";
    }
    
    @GetMapping("/cars/add")
    public String showAddForm(Car car) {
        return "add-car";
    }  
    
    @PostMapping("/cars/save")
    public String addCar(@Valid Car car, BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
            return "add-car";
        }
        carService.insert(car);
        String message = "Auto bylo úspěšně přidáno.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/cars";
    }
    
    @GetMapping("/cars/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Car car = carService.findById(id);
        
        model.addAttribute("car", car);
        return "update-car";
    }
    
    @PostMapping("/cars/update/{id}")
    public String updateCar(@PathVariable("id") long id, @Valid Car car, 
      BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
        	car.setId(id);
            return "update-car";
        }
        
        Car existingCar = carService.findById(id);
        existingCar.setName(car.getName());
        existingCar.setLicencePlate(car.getLicencePlate());
        existingCar.setMileage(car.getMileage());
        String message = "Auto s id " + id + " bylo úspěšně upraveno.";
        attributes.addFlashAttribute("message", message);
        carService.update(existingCar);
        return "redirect:/cars";
    }
       
    @GetMapping("/cars/delete/{id}")
    public String deleteCar(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Car car = carService.findById(id);
        String message = "Auto s id " + id + " byl úspěšně smazáno.";
        attributes.addFlashAttribute("message", message);
        
        //in case we are using JDBC, we have to manually delete all car's deliveries before deleting the customer
        if(customDataSource.equals("jdbc")) {
        	deliveryService.deleteByCarId(id);
        }
    	carService.delete(car);
        return "redirect:/cars";
    }
    
    @GetMapping("/cars/deliveries/{id}")
    public String showDeliveries(@PathVariable("id") long id, Model model) {
    	Car car = carService.findById(id);

    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : car.getDeliveries()) {
    		deliveriesCount++;
		}
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : car.getDeliveries()) {
    		deliveriesCreationDates[i] = delivery.creationDate.toString();
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	
        model.addAttribute("car", car);
        return "car-deliveries";
    }
}