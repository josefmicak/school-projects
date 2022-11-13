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

import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;
import cz.restauracev2.security.Encoder;
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.EmployeeService;
import cz.restauracev2.service.PersonService;

@Controller
public class EmployeeController {	
	
	@Autowired
	private EmployeeService employeeService;
	@Autowired
	private DeliveryService deliveryService;
	@Autowired
	private PersonService personService;
	@Autowired
	private Encoder encoder;
	@Value("${customdatasource}")
	private String customDataSource;
	
    @GetMapping("/employees")
    public String showEmployeeList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("employees", employeeService.findAll());
    	model.addAttribute("message", message);
        return "employees";
    }
    
    @GetMapping("/employees/add")
    public String showAddForm(Employee employee) {
        return "add-employee";
    }  
    
    @PostMapping("/employees/save")
    public String addEmployee(@Valid Employee employee, BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
            return "add-employee";
        }
        
        String message;
        
        //check if person with this login already exists, don't add new employee if true
        long personCountByLogin = personService.findPersonCountByLogin(employee.login);
        if(personCountByLogin > 0) {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }
        else {
        	employee.isApproved = true;
            employee.setPassword(encoder.passwordEncoder().encode(employee.password));
            employeeService.insert(employee);
            message = "Zaměstnanec byl úspěšně přidán.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/employees";
    }
    
    @GetMapping("/employees/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Employee employee = employeeService.findById(id);
        
        model.addAttribute("employee", employee);
        return "update-employee";
    }
    
    @PostMapping("/employees/update/{id}")
    public String updateEmployee(@PathVariable("id") long id, @Valid Employee employee, 
      BindingResult result, Model model, RedirectAttributes attributes) throws Exception {
        if (result.hasErrors()) {
        	employee.setId(id);
            return "update-employee";
        }
        
        String message;
        boolean isDuplicateLogin = false;
        
        //check if person with this login already exists, don't edit employee if true
        long personCountByLogin = personService.findPersonCountByLogin(employee.login);
        if(personCountByLogin > 0) {
        	Person personByLogin = personService.findByLogin(employee.login);
        	if(personByLogin.id != employee.id) {
        		isDuplicateLogin = true;
        	}	
        }
        
        if(!isDuplicateLogin) {
            Employee existingEmployee = employeeService.findById(id);
            existingEmployee.setName(employee.name);
            existingEmployee.setLogin(employee.login);
            existingEmployee.setPassword(employee.password);
            existingEmployee.setEmail(employee.email);
            existingEmployee.setSalary(employee.salary);
            existingEmployee.setIsApproved(true);
            message = "Zaměstnanec s id " + id + " byl úspěšně upraven.";
            employeeService.update(existingEmployee);
        }
        else {
        	message = "Chyba: již existuje jiná osoba s tímto loginem.";
        }

        attributes.addFlashAttribute("message", message);
        return "redirect:/employees";
    }
       
    @GetMapping("/employees/delete/{id}")
    public String deleteEmployee(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Employee employee = employeeService.findById(id);
        String message = "Zaměstnanec s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
        
        //in case we are using JDBC, we have to manually delete all customer's deliveries before deleting the customer
        if(customDataSource.equals("jdbc")) {
        	deliveryService.deleteByEmployeeId(id);
        }
    	employeeService.delete(employee);
        return "redirect:/employees";
    }
    
    @GetMapping("/employees/deliveries/{id}")
    public String showDeliveries(@PathVariable("id") long id, Model model) {
    	Employee employee = employeeService.findById(id);

    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : employee.deliveries) {
    		deliveriesCount++;
		}
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : employee.deliveries) {
    		deliveriesCreationDates[i] = delivery.creationDate.toString();
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	
        model.addAttribute("employee", employee);
        return "employee-deliveries";
    }
}