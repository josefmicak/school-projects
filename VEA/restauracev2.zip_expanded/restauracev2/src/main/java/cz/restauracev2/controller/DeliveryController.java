package cz.restauracev2.controller;

import java.time.LocalDateTime;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.convert.ConversionService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.service.CarService;
import cz.restauracev2.service.CustomDateTypeService;
import cz.restauracev2.service.CustomerService;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.EmployeeService;

@Controller
public class DeliveryController {	
	
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	private EmployeeService employeeService;
	@Autowired
	private CustomerService customerService;
	@Autowired
	private CarService carService;
	@Autowired
	private CustomDateTypeService customDateTypeService;
	/*@Autowired
	ConversionService conversionService;*/
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/deliveries")
    public String showOrderList(Model model, @ModelAttribute("message") String message) {
    	Iterable<Delivery> deliveries = deliveryService.findAll();
    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : deliveries) {
    		deliveriesCount++;
		}
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : deliveries) {
    		//CustomDateType customDateType = conversionService.convert(String.valueOf(delivery.creationDate), CustomDateType.class);
    		//long creationDateId = delivery.creationDate.getCustomDateTypeId();
    		//System.out.println("new: " + creationDateId);
    		CustomDateType customDateType = customDateTypeService.findById(delivery.creationDate.getCustomDateTypeId());
    		deliveriesCreationDates[i] = customDateType.toString();
    		//deliveriesCreationDates[i] = delivery.creationDate.toString();
    		//deliveriesCreationDates[i] = delivery.creationDate.format(myFormatObj);
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	model.addAttribute("deliveries", deliveries);
    	model.addAttribute("message", message);
        return "deliveries";
    }
    
    @GetMapping("/deliveries/add")
    public String showAddForm(Model model, Delivery delivery, RedirectAttributes attributes) {
    	//to add a delivery, there has to be at least one employee, one customer and one car
    	Iterable<Employee> employees = employeeService.findAll();
    	int employeesCount = 0;
    	for(Employee employee : employees) {
    		employeesCount++;
		}
    	Iterable<Customer> customers = customerService.findAll();
    	int customersCount = 0;
    	for(Customer customer : customers) {
    		customersCount++;
		}
    	Iterable<Car> cars = carService.findAll();
    	int carsCount = 0;
    	for(Car car : cars) {
    		carsCount++;
		}
    	if(employeesCount == 0 || customersCount == 0 || carsCount == 0) {
            String message = "Chyba: pro přidání objednávky musí existovat alespoň jeden zaměstnanec, jeden zákazník a jedno auto.";
            attributes.addFlashAttribute("message", message);
            return "redirect:/deliveries";
    	}
    	model.addAttribute("employees", employees);
    	model.addAttribute("customers", customers);
    	model.addAttribute("cars", cars);
        return "add-delivery";
    }  
    
    @PostMapping("/deliveries/save")
    public String addDelivery(@Valid Delivery delivery, BindingResult result, Model model, RedirectAttributes attributes,
    		String employeeId, String customerId, String carId) {
        if (result.hasErrors()) {
        	System.out.println("error ");
            return "add-delivery";
        }
        Employee employee = employeeService.findById(Long.valueOf(employeeId));
        Customer customer = customerService.findById(Long.valueOf(customerId));
        Car car = carService.findById(Long.valueOf(carId));
        
        delivery.employee = employee;
        delivery.customer = customer;
        delivery.car = car;
        deliveryService.insert(delivery);
        String message = "Objednávka byla úspěšně přidána.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/deliveries";
    }
    
    @GetMapping("/deliveries/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Delivery delivery = deliveryService.findById(id);
        
        model.addAttribute("delivery", delivery);
    	model.addAttribute("employees", employeeService.findAll());
    	model.addAttribute("customers", customerService.findAll());
    	model.addAttribute("cars", carService.findAll());
        return "update-delivery";
    }
    
    @PostMapping("/deliveries/update/{id}")
    public String updateDelivery(@PathVariable("id") long id, @Valid Delivery delivery, 
      BindingResult result, Model model, RedirectAttributes attributes,
      	String employeeId, String customerId, String carId, double price) {
        Employee employee = employeeService.findById(Long.valueOf(employeeId));
        Customer customer = customerService.findById(Long.valueOf(customerId));
        Car car = carService.findById(Long.valueOf(carId));
        
        Delivery existingDelivery = deliveryService.findById(id);
        CustomDateType existingDeliveryCreationDate = existingDelivery.getCreationDate();
        existingDelivery.id = id;
        existingDelivery.employee = employee;
        existingDelivery.customer = customer;
        existingDelivery.car = car;
        existingDelivery.creationDate = existingDeliveryCreationDate;//TODO: odebrat?
        existingDelivery.price = price;
        String message = "Objednávka s id " + id + " byla úspěšně upravena.";
        attributes.addFlashAttribute("message", message);
        deliveryService.update(existingDelivery);
        return "redirect:/deliveries";
    }
        
    @GetMapping("/deliveries/delete/{id}")
    public String deleteDelivery(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Delivery delivery = deliveryService.findById(id);
        String message = "Objednávka s id " + id + " byla úspěšně smazána.";
        attributes.addFlashAttribute("message", message);
    	deliveryService.delete(delivery);
        return "redirect:/deliveries";
    }
}