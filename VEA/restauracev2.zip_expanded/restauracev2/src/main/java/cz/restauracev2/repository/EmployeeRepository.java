package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.Employee;

public interface EmployeeRepository {
	List<Employee> findAll();
	
	Employee findById(long id);
	
	void insert(Employee employee);
	
	void update(Employee employee);
	
	void delete(Employee employee);
}
