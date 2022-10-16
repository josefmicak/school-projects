package cz.restaurace.controller;

import java.time.format.DateTimeFormatter;

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

@Controller
public class CustomerController {	
	
	@Autowired
	private CustomerRepository customerRepository;
	
    @GetMapping("/customers")
    public String showCustomerList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("customers", customerRepository.findAll());
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
        
        customerRepository.save(customer);
        Long id = customerRepository.save(customer).getCustomerId();
        String message = "Zákazník s id " + id + " byl úspěšně přidán.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/customers";
    }
    
    @GetMapping("/customers/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Customer customer = customerRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zákazník s id " + id + " nebyl nalezen."));
        
        model.addAttribute("customer", customer);
        return "update-customer";
    }
    
    @PostMapping("/customers/update/{id}")
    public String updateCustomer(@PathVariable("id") long id, @Valid Customer customer, 
      BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
        	customer.setCustomerId(id);
            return "update-customer";
        }
        Customer existingCustomer = customerRepository.findById(id).get();
        existingCustomer = customer;
        existingCustomer.setCustomerId(id);
        String message = "Zákazník s id " + id + " byl úspěšně upraven.";
        attributes.addFlashAttribute("message", message);
        customerRepository.save(existingCustomer);
        return "redirect:/customers";
    }
        
    @GetMapping("/customers/delete/{id}")
    public String deleteCustomer(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Customer customer = customerRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zákazník s id " + id + " nebyl nalezen."));
        String message = "Zákazník s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
    	customerRepository.delete(customer);
        return "redirect:/customers";
    }
    
    @GetMapping("/customers/deliveries/{id}")
    public String showDeliveries(@PathVariable("id") long id, Model model) {
    	Customer customer = customerRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zákazník s id " + id + " nebyl nalezen."));

    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : customer.deliveries) {
    		deliveriesCount++;
		}
    	DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd.MM.yyyy HH:mm:ss");
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : customer.deliveries) {
    		deliveriesCreationDates[i] = delivery.creationDate.format(myFormatObj);
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	
        model.addAttribute("customer", customer);
        return "customer-deliveries";
    }
}