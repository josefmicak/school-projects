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
        long personCountByLogin = personService.findPersonCountByLogin(person.getLogin());
        if(personCountByLogin > 0) {
        	message = "Chyba: registraci nešlo vytvořit. Zkuste to prosím znovu";
        }
        else {
            Person newPerson;
            if(personType.equals("employee")) {
            	Employee employee = new Employee();
            	employee.setName(person.getName());
            	employee.setLogin(person.getLogin());
            	employee.setPassword(person.getPassword());
            	employee.setEmail(person.getEmail());
            	employee.setSalary(0);
            	employee.setIsApproved(false);
            	newPerson = employee;
            }
            else {
            	Customer customer = new Customer();
            	customer.setName(person.getName());
            	customer.setLogin(person.getLogin());
            	customer.setPassword(person.getPassword());
            	customer.setEmail(person.getEmail());
            	customer.setAddress(address);
            	customer.setIsApproved(false);
            	newPerson = customer;
            }
            
            personService.insert(newPerson);
            message = "Registrace úspěšná. Nyní musí registraci schválit administrátor.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/login";
    }
}