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
import cz.restaurace.repository.DeliveryRepository;
import cz.restaurace.repository.EmployeeRepository;

@Controller
public class EmployeeController {	
	
	@Autowired
	private EmployeeRepository employeeRepository;
	@Autowired
	private DeliveryRepository deliveryRepository;
	
    @GetMapping("/employees")
    public String showEmployeeList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("employees", employeeRepository.findAll());
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
        
        employeeRepository.save(employee);
        Long id = employeeRepository.save(employee).getEmployeeId();
        String message = "Zaměstnanec s id " + id + " byl úspěšně přidán.";
        attributes.addFlashAttribute("message", message);
        return "redirect:/employees";
    }
    
    @GetMapping("/employees/edit/{id}")
    public String showUpdateForm(@PathVariable("id") long id, Model model) {
    	Employee employee = employeeRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + id + " nebyl nalezen."));
        
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
        
        Employee existingEmployee = employeeRepository.findById(id).get();
        existingEmployee = employee;
        existingEmployee.setEmployeeId(id);
        String message = "Zaměstnanec s id " + id + " byl úspěšně upraven.";
        attributes.addFlashAttribute("message", message);
        employeeRepository.save(existingEmployee);
        return "redirect:/employees";
    }
        
    @GetMapping("/employees/delete/{id}")
    public String deleteEmployee(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Employee employee = employeeRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + id + " nebyl nalezen."));
        String message = "Zaměstnanec s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
    	employeeRepository.delete(employee);
        return "redirect:/employees";
    }
    
    @GetMapping("/employees/deliveries/{id}")
    public String showDeliveries(@PathVariable("id") long id, Model model) {
    	Employee employee = employeeRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Zaměstnanec s id " + id + " nebyl nalezen."));

    	//format date in view
    	int deliveriesCount = 0;
    	for(Delivery delivery : employee.deliveries) {
    		deliveriesCount++;
		}
    	DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd.MM.yyyy HH:mm:ss");
    	String[] deliveriesCreationDates = new String[deliveriesCount];
    	int i = 0;
    	for(Delivery delivery : employee.deliveries) {
    		deliveriesCreationDates[i] = delivery.creationDate.format(myFormatObj);
    		i++;
		}
    	model.addAttribute("deliveriesCreationDates", deliveriesCreationDates);
    	
        model.addAttribute("employee", employee);
        return "employee-deliveries";
    }
}