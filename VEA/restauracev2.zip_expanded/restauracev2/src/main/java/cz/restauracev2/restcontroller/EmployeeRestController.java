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

import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;
import cz.restauracev2.service.PersonService;

@RestController
public class EmployeeRestController {
	
	@Autowired
	private PersonService personService;
	
    @GetMapping("/api/employees")
    List<Person> showEmployeeList(){
    	return personService.findAllEmployees();
    }
    
    @PostMapping("/api/employees")
    ResponseEntity<String> addEmployee(@RequestBody Employee employee){
		long personCountByLogin = personService.findPersonCountByLogin(employee.login);
		if(personCountByLogin > 0) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživatele s loginem " + employee.login + " nelze přidat."
	                		+ " Již existuje jiný uživatel s tímto loginem.");
		}
		else {
			personService.insert(employee);
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Zaměstnanec byl úspěšně přidán.");
		}
    }
    
    @PutMapping("/api/employees/{id}")
    ResponseEntity<String> updateEmployee(@RequestBody Employee employee, @PathVariable Long id) throws Exception{	
		if(personService.isUpdateLoginDuplicate(employee)) {
	        return ResponseEntity.badRequest()
	                .body("Chyba: uživateli nelze nastavit login " + employee.login + ". Již existuje jiný uživatel s tímto loginem.");
		}
		else {
	        Employee existingEmployee = (Employee) personService.findById(id);
	        existingEmployee.setName(employee.name);
	        existingEmployee.setLogin(employee.login);
	        //existingEmployee.setPassword(employee.password);
	        existingEmployee.setEmail(employee.email);
	        existingEmployee.setSalary(employee.salary);
	        existingEmployee.setIsApproved(employee.isApproved);
	        personService.update(existingEmployee);
	        return ResponseEntity.status(HttpStatus.OK)
	                .body("Zaměstnanec byl úspěšně upraven.");
		}
    }
    
    @DeleteMapping("/api/employees/{id}")
    ResponseEntity<String> deleteEmployee(@PathVariable Long id){
    	Employee employee = (Employee) personService.findById(id);
    	personService.delete(employee);
        return ResponseEntity.status(HttpStatus.OK)
                .body("Zaměstnanec byl úspěšně smazán.");
    }

}
