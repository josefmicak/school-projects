package cz.restauracev2.controller;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;
import cz.restauracev2.service.PersonService;

@Controller
public class IndexController {
	
	@Autowired
	private PersonService personService;
	
    @GetMapping("/")
    public String index() {
        return "login";
    }
    
    @GetMapping("/login")
    public String showLoginForm(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("message", message);
        return "login";
    }
    
    @GetMapping("/logout")
    public String showLogout() {
        return "logout";
    }
    
    @GetMapping("/employeemenu")
    public String showEmployeeMenu() {
        return "employee-menu";
    }
    
    @GetMapping("/awaitingapproval")
    public String showAwaitingApprovalPage() {
        return "awaiting-approval";
    }
    
    @GetMapping("/register")
    public String showRegistrationForm(Person person) {
        return "register";
    }
	
    @PostMapping("/register/submit")
    public String finishRegistration(@Valid Person person, BindingResult result, Model model, RedirectAttributes attributes, String personType, String address) {
        if (result.hasErrors()) {
            return "register";
        }
        String message;
        
        //check if person with this login already exists, don't add new person if true
        long personCountByLogin = personService.findPersonCountByLogin(person.login);
        if(personCountByLogin > 0) {
        	message = "Chyba: registraci nešlo vytvořit. Zkuste to prosím znovu";
        }
        else {
            Person newPerson;
            if(personType.equals("employee")) {
            	Employee employee = new Employee();
            	employee.name = person.name;
            	employee.login = person.login;
            	employee.password = person.password;
            	employee.email = person.email;
            	employee.salary = 0;
            	employee.isApproved = false;
            	newPerson = employee;
            }
            else {
            	Customer customer = new Customer();
            	customer.name = person.name;
            	customer.login = person.login;
            	customer.password = person.password;
            	customer.email = person.email;
            	customer.address = address;
            	customer.isApproved = false;
            	newPerson = customer;
            }
            
            personService.insert(newPerson);
            message = "Registrace úspěšná. Nyní musí registraci schválit administrátor.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/login";
    }
    
  /*  @GetMapping("/registrations")
    public String showRegistrationList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("registrations", personService.findAllRegistrations());
    	model.addAttribute("message", message);
        return "registrations";
    }*/
}