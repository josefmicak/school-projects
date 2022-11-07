package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;

import cz.restauracev2.model.Employee;
import cz.restauracev2.repository.EmployeeRepository;
import cz.restauracev2.repository.EmployeeRepositoryJdbc;
import cz.restauracev2.repository.EmployeeRepositoryJpa;

@Service
public class EmployeeService {

	private EmployeeRepository employeeRepository;
	@Autowired
	private EmployeeRepositoryJpa employeeRepositoryJpa;
	@Autowired
	private EmployeeRepositoryJdbc employeeRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	
	@Autowired
	public void setEmployeeRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.employeeRepository = employeeRepositoryJpa;
				break;
			case "jdbc":
				this.employeeRepository = employeeRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	@Log
	public List<Employee> findAll() {
		return employeeRepository.findAll();
	}
	
	@Log
	public Employee findById(long id) {
		return employeeRepository.findById(id);
	}

	@Log
	public void insert(Employee employee) {
		employeeRepository.insert(employee);
	}
	
	@Log
	public void update(Employee employee) {
		employeeRepository.update(employee);
	}
	
	@Log
	public void delete(Employee employee) {
		employeeRepository.delete(employee);
	}
}
