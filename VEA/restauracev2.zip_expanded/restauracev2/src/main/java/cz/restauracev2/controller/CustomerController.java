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

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.service.CustomerService;
import cz.restauracev2.service.DeliveryService;

@Controller
public class CustomerController {	
	
	@Autowired
	private CustomerService customerService;
	@Autowired
	private DeliveryService deliveryService;
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/customers")
    public String showCustomerList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("customers", customerService.findAll());
    	model.addAttribute("message", message);
        return "customers";
    }
    
    @GetMapping("/customers/add")
    public String showAddForm(Customer customer) {
        return "add-customer";
    }  
    
    @PostMapping("/customers/save")
    public String addCustomer(@Valid Customer customer, BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
            return "add-customer";
        }
        
        customerService.insert(customer);
        String message = "Zákazník byl úspěšně přidán.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/customers";
    }
    
    @GetMapping("/customers/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Customer customer = customerService.findById(id);
        
        model.addAttribute("customer", customer);
        return "update-customer";
    }
    
    @PostMapping("/customers/update/{id}")
    public String updateCustomer(@PathVariable("id") long id, @Valid Customer customer, 
      BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
        	customer.setId(id);
            return "update-customer";
        }
        Customer existingCustomer = customerService.findById(id);
        existingCustomer.setName(customer.name);
        existingCustomer.setEmail(customer.email);
        existingCustomer.setAddress(customer.address);
        String message = "Zákazník s id " + id + " byl úspěšně upraven.";
        attributes.addFlashAttribute("message", message);
        customerService.update(existingCustomer);
        return "redirect:/customers";
    }
        
    @GetMapping("/customers/delete/{id}")
    public String deleteCustomer(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Customer customer = customerService.findById(id);
        String message = "Zákazník s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
        
        //in case we are using JDBC, we have to manually delete all customer's deliveries before deleting the customer
        if(customDataSource.equals("jdbc")) {
        	deliveryService.deleteByCustomerId(id);
        }
    	customerService.delete(customer);
        return "redirect:/customers";
    }
    
    @GetMapping("/customers/deliveries/{id}")
    public String showDeliveries(@PathVariable("id") long id, Model model) {
    	Customer customer = customerService.findById(id);

    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : customer.deliveries) {
    		deliveriesCount++;
		}
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : customer.deliveries) {
    		deliveriesCreationDates[i] = delivery.creationDate.toString();
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	
        model.addAttribute("customer", customer);
        return "customer-deliveries";
    }
}