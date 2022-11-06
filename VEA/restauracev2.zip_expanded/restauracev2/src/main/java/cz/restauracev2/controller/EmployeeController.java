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
import cz.restauracev2.service.DeliveryService;
import cz.restauracev2.service.EmployeeService;

@Controller
public class EmployeeController {	
	
	@Autowired
	private EmployeeService employeeService;
	@Autowired
	private DeliveryService deliveryService;
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
        
        employeeService.insert(employee);
        String message = "Zaměstnanec byl úspěšně přidán.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/employees";
    }
    
    @GetMapping("/employees/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Employee employee = employeeService.findById(id);
         // .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + id + " nebyl nalezen."));
        
        model.addAttribute("employee", employee);
        return "update-employee";
    }
    
    @PostMapping("/employees/update/{id}")
    public String updateEmployee(@PathVariable("id") long id, @Valid Employee employee, 
      BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
        	employee.setEmployeeId(id);
            return "update-employee";
        }
        
        Employee existingEmployee = employeeService.findById(id);
        existingEmployee.setEmployeeName(employee.name);
        existingEmployee.setEmployeeEmail(employee.email);
        String message = "Zaměstnanec s id " + id + " byl úspěšně upraven.";
        attributes.addFlashAttribute("message", message);
        employeeService.update(existingEmployee);
        return "redirect:/employees";
    }
       
    @GetMapping("/employees/delete/{id}")
    public String deleteEmployee(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Employee employee = employeeService.findById(id);
    //      .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + id + " nebyl nalezen."));
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