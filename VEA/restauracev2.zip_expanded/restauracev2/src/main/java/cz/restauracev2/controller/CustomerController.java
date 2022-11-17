package cz.restauracev2.controller;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
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
import cz.restauracev2.model.Person;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.PersonService;

@Controller
public class CustomerController {	
	
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	private PersonService personService;
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/customers")
    public String showCustomerList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("customers", personService.findAllCustomers());
    	model.addAttribute("message", message);
        return "customers";
    }
    
    @GetMapping("/customers/add")
    public String showAddForm(Customer customer) {
        return "add-customer";
    }  
    
    @PostMapping("/customers/save")
    public String addCustomer(@Valid Customer customer, BindingResult result, Model model, RedirectAttributes attributes)  {
        if (result.hasErrors()) {
            return "add-customer";
        }
        
        String message;
        
        //check if person with this login already exists, don't add new customer if true
        long personCountByLogin = personService.findPersonCountByLogin(customer.login);
        if(personCountByLogin > 0) {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }
        else {
        	customer.isApproved = true;
            personService.insert(customer);
            message = "Zákazník byl úspěšně přidán.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/customers";
    }
    
    @GetMapping("/customers/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Customer customer = (Customer) personService.findById(id);
        
        model.addAttribute("customer", customer);
        return "update-customer";
    }
    
    @PostMapping("/customers/update/{id}")
    public String updateCustomer(@PathVariable("id") long id, @Valid Customer customer, 
      BindingResult result, Model model, RedirectAttributes attributes) throws Exception {
        if (result.hasErrors()) {
        	customer.setId(id);
            return "update-customer";
        }
        
        String message;
        boolean isDuplicateLogin = false;
        
      //check if person with this login already exists, don't edit customer if true
        long personCountByLogin = personService.findPersonCountByLogin(customer.login);
        if(personCountByLogin > 0) {
        	Person personByLogin = personService.findByLogin(customer.login);
        	if(personByLogin.id != customer.id) {
        		isDuplicateLogin = true;
        	}	
        }
        
        if(!isDuplicateLogin) {
            Customer existingCustomer = (Customer) personService.findById(id);
            existingCustomer.setName(customer.name);
            existingCustomer.setLogin(customer.login);
            existingCustomer.setPassword(customer.password);
            existingCustomer.setEmail(customer.email);
            existingCustomer.setAddress(customer.address);
            existingCustomer.setIsApproved(true);
            message = "Zákazník s id " + id + " byl úspěšně upraven.";
            personService.update(existingCustomer);
        }
        else {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }

        attributes.addFlashAttribute("message", message);  
        return "redirect:/customers";
    }
        
    @GetMapping("/customers/delete/{id}")
    public String deleteCustomer(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Customer customer = (Customer) personService.findById(id);
        String message = "Zákazník s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
        
        //in case we are using JDBC, we have to manually delete all customer's deliveries before deleting the customer
        if(customDataSource.equals("jdbc")) {
        	deliveryService.deleteByCustomerId(id);
        }
    	personService.delete(customer);
        return "redirect:/customers";
    }
    
    @GetMapping("/customerdeliveries/{id}")
    @PreAuthorize("#id == authentication.principal.getUserId() or hasAuthority('ADMIN')")//assure that the customer can only view his own delivery list
    public String showDeliveries(@PathVariable("id") long id, Model model) throws Exception {
    	//we pass the role of the current user because both employees and customers visit this page, and we want some elements to be visible only for the employees
    	UserDetails userDetails = (UserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
    	String currentUserUsername = userDetails.getUsername();
    	Person personByLogin = personService.findByLogin(currentUserUsername);
    	model.addAttribute("currentUser", personByLogin.getDiscriminatorValue());
    	
    	Customer customer = (Customer) personService.findById(id);

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