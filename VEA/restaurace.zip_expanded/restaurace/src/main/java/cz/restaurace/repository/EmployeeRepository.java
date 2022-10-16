package cz.restaurace.repository;

import org.springframework.data.repository.CrudRepository;

import cz.restaurace.model.Employee;

public interface EmployeeRepository extends CrudRepository<Employee, Long> {}