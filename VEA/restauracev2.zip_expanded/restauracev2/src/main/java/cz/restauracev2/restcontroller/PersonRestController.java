package cz.restauracev2.restcontroller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;
import cz.restauracev2.service.PersonService;

@RestController
public class PersonRestController {
	
	@Autowired
	private PersonService personService;
	
    @GetMapping("/api/persons")
    List<Person> showPersonList(){
    	return personService.findAll();
    }
    
    @PostMapping("/api/persons")
    ResponseEntity<String> addPerson(@RequestParam String personType, @RequestParam String salary,
    		@RequestParam String address, @RequestBody Person person){
		long personCountByLogin = personService.findPersonCountByLogin(person.login);
		if(personCountByLogin > 0) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživatele s loginem " + person.login + " nelze přidat."
	                		+ " Již existuje jiný uživatel s tímto loginem.");
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
	        	personService.insert(newPerson);
	    	}
	    	else if (personType.equals("customer")){
	        	Customer customer = new Customer();
	        	customer.name = person.name;
	        	customer.login = person.login;
	        	customer.password = person.password;
	        	customer.email = person.email;
	        	customer.address = address;
	        	customer.isApproved = true;
	        	newPerson = customer;
	        	personService.insert(newPerson);
	    	}
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Osoba byla úspěšně přidána.");
		}
    }
    
    @PutMapping("/api/persons/{id}")
    ResponseEntity<String> editPerson(@PathVariable Long id, @RequestParam String salary,
    		@RequestParam String address, @RequestBody Person person) {
		if(personService.isUpdateLoginDuplicate(person)) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživateli nelze nastavit login " + person.login + ". Již existuje jiný uživatel s tímto loginem.");
		}
		else {
	    	Person existingPerson = personService.findById(id);
	    	String personType = existingPerson.getDiscriminatorValue();
	    	if(personType.equals("employee")) {
	        	Employee employee = new Employee();
	        	employee.id = id;
	        	employee.name = person.name;
	        	employee.login = person.login;
	        	employee.password = existingPerson.password;
	        	employee.email = person.email;
	        	employee.salary = Double.parseDouble(salary);
	        	employee.isApproved = person.isApproved;
	        	existingPerson = employee;
	        	personService.update(existingPerson);
	    	}
	    	else if (personType.equals("customer")){
	        	Customer customer = new Customer();
	        	customer.id = id;
	        	customer.name = person.name;
	        	customer.login = person.login;
	        	customer.password = existingPerson.password;
	        	customer.email = person.email;
	        	customer.address = address;
	        	customer.isApproved = person.isApproved;
	        	existingPerson = customer;
	        	personService.update(existingPerson);
	    	}
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Osoba byla úspěšně upravena.");
		}
    }
    
    @DeleteMapping("/api/persons/{id}")
    ResponseEntity<String> deletePerson(@PathVariable Long id){
    	Person person = personService.findById(id);
    	personService.delete(person);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Osoba byla úspěšně smazána.");
    }

}
