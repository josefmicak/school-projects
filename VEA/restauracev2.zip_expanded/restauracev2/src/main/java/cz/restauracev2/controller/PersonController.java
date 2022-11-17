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
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.PersonService;

@Controller
public class PersonController {	
	
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	private PersonService personService;
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/persons")
    public String showPersonList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("persons", personService.findAll());
    	model.addAttribute("message", message);
        return "persons";
    }
    
    @GetMapping("/persons/add")
    public String showAddForm(Person person) {
        return "add-person";
    }  
    
    @PostMapping("/persons/save")
    public String addPerson(@Valid Person person, BindingResult result, Model model, RedirectAttributes attributes, String personType, String salary, String address) {
        if (result.hasErrors()) {
            return "add-person";
        }
        String message;
        
        //check if person with this login already exists, don't add new person if true
        long personCountByLogin = personService.findPersonCountByLogin(person.login);
        if(personCountByLogin > 0) {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }
        else {
            Person newPerson;
            if(personType.equals("employee")) {
            	Employee employee = new Employee();
            	employee.name = person.name;
            	employee.login = person.login;
            	employee.password = person.password;
            	employee.email = person.email;
            	employee.salary = Double.parseDouble(salary);
            	employee.isApproved = true;
            	newPerson = employee;
            }
            else {
            	Customer customer = new Customer();
            	customer.name = person.name;
            	customer.login = person.login;
            	customer.password = person.password;
            	customer.email = person.email;
            	customer.address = address;
            	customer.isApproved = true;
            	newPerson = customer;
            }
            
            personService.insert(newPerson);
            message = "Osoba byla úspěšně přidána.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/persons";
    }
    
    @GetMapping("/persons/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Person person = personService.findById(id);
        model.addAttribute("person", person);
        return "update-person";
    }
    
    @PostMapping("/persons/update/{id}")
    public String updatePerson(@PathVariable("id") long id, @Valid Person person, 
      BindingResult result, Model model, RedirectAttributes attributes, String personType, String salary, String address) throws Exception  {
        if (result.hasErrors()) {
        	person.setId(id);
            return "update-person";
        }
        
        String message;
        boolean isDuplicateLogin = false;
        
        //check if person with this login already exists, don't edit person if true
        long personCountByLogin = personService.findPersonCountByLogin(person.login);
        if(personCountByLogin > 0) {
        	Person personByLogin = personService.findByLogin(person.login);
        	if(personByLogin.id != person.id) {
        		isDuplicateLogin = true;
        	}	
        }
        
        if(!isDuplicateLogin) {
            Person existingPerson;
            if(personType.equals("employee")) {
            	Employee employee = new Employee();
            	employee.id = person.id;
            	employee.name = person.name;
            	employee.login = person.login;
            	employee.password = person.password;
            	employee.email = person.email;
            	employee.salary = Double.parseDouble(salary);
            	employee.isApproved = true;
            	existingPerson = employee;
            }
            else {
            	Customer customer = new Customer();
            	customer.id = id;
            	customer.name = person.name;
            	customer.login = person.login;
            	customer.password = person.password;
            	customer.email = person.email;
            	customer.address = address;
            	customer.isApproved = true;
            	existingPerson = customer;
            }
            message = "Osoba s id " + id + " byla úspěšně upravena.";
            personService.update(existingPerson);
        }
        else {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/persons";
    }
       
    @GetMapping("/persons/delete/{id}")
    public String deletePerson(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Person person = personService.findById(id);
        String message = "Osoba s id " + id + " byla úspěšně smazána.";
        attributes.addFlashAttribute("message", message);
        
        //in case we are using JDBC, we have to manually delete all customer's deliveries before deleting the customer
        if(customDataSource.equals("jdbc")) {
        	if(person.getDiscriminatorValue().equals("employee")) {
        		deliveryService.deleteByEmployeeId(id);
        	}
        	else {
        		deliveryService.deleteByCustomerId(id);
        	}
        }
    	personService.delete(person);
        return "redirect:/persons";
    }
    
    
    @GetMapping("/persons/registrations")
    public String showRegistrationList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("registrations", personService.findAllRegistrations());
    	model.addAttribute("message", message);
        return "registrations";
    }
    
    @GetMapping("/persons/registrations/approve/{id}")
    public String updatePerson(@PathVariable("id") long id, @Valid Person person, 
    		BindingResult result, Model model, RedirectAttributes attributes, String personType, String address) throws Exception  {
        if (result.hasErrors()) {
        	person.setId(id);
            return "/persons/registrations";
        }
        
        Person existingPerson = personService.findById(id);
        existingPerson.isApproved = true;
        String message = "Registrace osoby s id " + id + " byla úspěšně schválena.";
        personService.update(existingPerson);
        attributes.addFlashAttribute("message", message);
        return "redirect:/persons/registrations";
    }

    @GetMapping("/persons/registrations/delete/{id}")
    public String deleteRegistration(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Person person = personService.findById(id);
        String message = "Registrace osoby s id " + id + " byla úspěšně smazána.";
        attributes.addFlashAttribute("message", message);       
    	personService.delete(person);
        return "redirect:/persons/registrations";
    }
}