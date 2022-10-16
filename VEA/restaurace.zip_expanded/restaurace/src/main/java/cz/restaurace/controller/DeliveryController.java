package cz.restaurace.controller;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import cz.restaurace.model.Customer;
import cz.restaurace.model.Delivery;
import cz.restaurace.model.Employee;
import cz.restaurace.repository.CustomerRepository;
import cz.restaurace.repository.DeliveryRepository;
import cz.restaurace.repository.EmployeeRepository;

@Controller
public class DeliveryController {	
	
	@Autowired
	private DeliveryRepository deliveryRepository;
	@Autowired
	private EmployeeRepository employeeRepository;
	@Autowired
	private CustomerRepository customerRepository;
	
    @GetMapping("/deliveries")
    public String showOrderList(Model model, @ModelAttribute("message") String message) {
    	Iterable<Delivery> deliveries = deliveryRepository.findAll();
    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : deliveries) {
    		deliveriesCount++;
		}
    	DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd.MM.yyyy HH:mm:ss");
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : deliveries) {
    		deliveriesCreationDates[i] = delivery.creationDate.format(myFormatObj);
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	model.addAttribute("deliveries", deliveries);
    	model.addAttribute("message", message);
        return "deliveries";
    }
    
    @GetMapping("/deliveries/add")
    public String showAddForm(Model model, Delivery delivery, RedirectAttributes attributes) {
    	//to add a delivery, there has to be at least one employee and one customer
    	Iterable<Employee> employees = employeeRepository.findAll();
    	int employeesCount = 0;
    	for(Employee employee : employees) {
    		employeesCount++;
		}
    	Iterable<Customer> customers = customerRepository.findAll();
    	int customersCount = 0;
    	for(Customer customer : customers) {
    		customersCount++;
		}
    	if(employeesCount == 0 || customersCount == 0) {
            String message = "Chyba: pro přidání objednávky musí existovat alespoň jeden zaměstnanec a alespoň jeden zákazník.";
            attributes.addFlashAttribute("message", message);
            return "redirect:/deliveries";
    	}
    	model.addAttribute("employees", employees);
    	model.addAttribute("customers", customers);
        return "add-delivery";
    }  
    
    @PostMapping("/deliveries/save")
    public String addDelivery(@Valid Delivery delivery, BindingResult result, Model model, RedirectAttributes attributes, String employeeId, String customerId) {
        if (result.hasErrors()) {
        	System.out.println("error ");
            return "add-delivery";
        }
        Employee employee = employeeRepository.findById(Long.valueOf(employeeId))
    	          .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + employeeId + " nebyl nalezen."));
        Customer customer = customerRepository.findById(Long.valueOf(customerId))
    	          .orElseThrow(() -> new IllegalArgumentException("Zákazník s id " + customerId + " nebyl nalezen."));
        
        delivery.employee = employee;
        delivery.customer = customer;
        delivery.creationDate = LocalDateTime.now();
        
        deliveryRepository.save(delivery);
        Long id = deliveryRepository.save(delivery).getDeliveryId();
        String message = "Objednávka s id " + id + " byla úspěšně přidána.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/deliveries";
    }
    
    @GetMapping("/deliveries/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Delivery delivery = deliveryRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Objednávka s id " + id + " nebyla nalezena."));
        
        model.addAttribute("delivery", delivery);
    	model.addAttribute("employees", employeeRepository.findAll());
    	model.addAttribute("customers", customerRepository.findAll());
        return "update-delivery";
    }
    
    @PostMapping("/deliveries/update/{id}")
    public String updateDelivery(@PathVariable("id") long id, @Valid Delivery delivery, 
      BindingResult result, Model model, RedirectAttributes attributes, String employeeId, String customerId) {
        if (result.hasErrors()) {
        	delivery.setDeliveryId(id);
            return "update-delivery";
        }
        
        Employee employee = employeeRepository.findById(Long.valueOf(employeeId))
  	          .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + employeeId + " nebyl nalezen."));
        Customer customer = customerRepository.findById(Long.valueOf(customerId))
  	          .orElseThrow(() -> new IllegalArgumentException("Zákazník s id " + customerId + " nebyl nalezen."));
        
        Delivery existingDelivery = deliveryRepository.findById(id).get();
        LocalDateTime existingDeliveryCreationDate = existingDelivery.getCreationDate();
        existingDelivery = delivery;
        existingDelivery.setDeliveryId(id);
        existingDelivery.employee = employee;
        existingDelivery.customer = customer;
        existingDelivery.creationDate = existingDeliveryCreationDate;
        String message = "Objednávka s id " + id + " byla úspěšně upravena.";
        attributes.addFlashAttribute("message", message);
        deliveryRepository.save(existingDelivery);
        return "redirect:/deliveries";
    }
        
    @GetMapping("/deliveries/delete/{id}")
    public String deleteDelivery(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Delivery delivery = deliveryRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Objednávka s id " + id + " nebyla nalezena."));
        String message = "Objednávka s id " + id + " byla úspěšně smazána.";
        attributes.addFlashAttribute("message", message);
    	deliveryRepository.delete(delivery);
        return "redirect:/deliveries";
    }
}