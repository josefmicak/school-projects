package cz.restauracev2.restcontroller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Person;
import cz.restauracev2.service.PersonService;

@RestController
public class CustomerRestController {
	
	@Autowired
	private PersonService personService;
	
    @GetMapping("/api/customers")
    List<Person> showCustomerList(){
    	return personService.findAllCustomers();
    }
    
    @PostMapping("/api/customers")
    ResponseEntity<String> addCustomer(@RequestBody Customer customer){
		long personCountByLogin = personService.findPersonCountByLogin(customer.login);
		if(personCountByLogin > 0) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživatele s loginem " + customer.login + " nelze přidat."
	                		+ " Již existuje jiný uživatel s tímto loginem.");
		}
		else {
			personService.insert(customer);
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Zákazník byl úspěšně přidán.");
		}
    }
    
    @PutMapping("/api/customers/{id}")
    ResponseEntity<String> updateCustomer(@RequestBody Customer customer, @PathVariable Long id) throws Exception{	 
		if(personService.isUpdateLoginDuplicate(customer)) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživateli nelze nastavit login " + customer.login + ". Již existuje jiný uživatel s tímto loginem.");
		}
		else {
	        Customer existingCustomer = (Customer)personService.findById(id);
	        existingCustomer.setName(customer.name);
	        existingCustomer.setLogin(customer.login);
	        //existingCustomer.setPassword(customer.password);
	        existingCustomer.setEmail(customer.email);
	        existingCustomer.setAddress(customer.address);
	        existingCustomer.setIsApproved(customer.isApproved);
	        personService.update(existingCustomer);
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Zákazník byl úspěšně upraven.");
		}
    }
    
    @DeleteMapping("/api/customers/{id}")
    ResponseEntity<String> deleteCustomer(@PathVariable Long id){
    	Customer customer = (Customer)personService.findById(id);
    	personService.delete(customer);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Zákazník byl úspěšně smazán.");
    }

}
