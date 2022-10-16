package cz.restaurace.controller;

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

import cz.restaurace.model.Employee;

import cz.restaurace.repository.EmployeeRepository;

@Controller
public class EmployeeController {	
	
	@Autowired
	private EmployeeRepository employeeRepository;
	
    @GetMapping("/employees")
    public String showEmployeeList(Model model, @ModelAttribute("message") String message) {
    	model.addAttribute("employees", employeeRepository.findAll());
    	model.addAttribute("message", message);
        return "employees";
    }
    
    @GetMapping("/employees/add")
    public String addEmployee(Employee employee) {
        return "add-employee";
    }  
    
    @PostMapping("/employees/save")
    public String addUser(@Valid Employee employee, BindingResult result, Model model, RedirectAttributes attributes) {
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
          .orElseThrow(() -> new IllegalArgumentException("Invalid employee Id:" + id));
        
        model.addAttribute("employee", employee);
        return "update-employee";
    }
    
    @PostMapping("/employees/update/{id}")
    public String updateUser(@PathVariable("id") long id, @Valid Employee employee, 
      BindingResult result, Model model, RedirectAttributes attributes) {
        if (result.hasErrors()) {
        	employee.setId(id);
            return "update-employee";
        }
        
        String message = "Zaměstnanec s id " + id + " byl úspěšně upraven.";
        attributes.addFlashAttribute("message", message);
        employeeRepository.save(employee);
        return "redirect:/employees";
    }
        
    @GetMapping("/employees/delete/{id}")
    public String deleteUser(@PathVariable("id") long id, Model model, RedirectAttributes attributes) {
    	Employee employee = employeeRepository.findById(id)
          .orElseThrow(() -> new IllegalArgumentException("Invalid employee Id:" + id));
        String message = "Zaměstnanec s id " + id + " byl úspěšně smazán.";
        attributes.addFlashAttribute("message", message);
    	employeeRepository.delete(employee);
        return "redirect:/employees";
    }
}