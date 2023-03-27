package cz.restauracev2.repository;

import javax.sql.DataSource;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;

@Repository
public class EmployeeRepositoryJdbc implements EmployeeRepository {
	
	@Autowired
	private DataSource dataSource;
	@Autowired
	private JdbcTemplate jdbcTemplate;
	@Autowired
	DeliveryRepositoryJdbc deliveryRepositoryJdbc;
	
	@Override
	public List<Employee> findAll() {
		List<Employee> employees = jdbcTemplate.query("SELECT * FROM person WHERE person_type = 'employee' AND is_approved = 1", new EmployeeMapper());
		for(Employee employee : employees){
			List<Delivery> deliveries = deliveryRepositoryJdbc.findEmployeeDeliveries(employee.id);
			employee.deliveries = deliveries;
		}
		return employees;
    }
	
	@Override
	public Employee findById(long id) {
		Employee employee = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new EmployeeMapper(), id);
		List<Delivery> deliveries = deliveryRepositoryJdbc.findEmployeeDeliveries(id);
		employee.deliveries = deliveries;
		return employee;
	}
	
    @Override
    @Transactional
    public void insert(Employee employee){
	    jdbcTemplate.update("INSERT INTO person (person_type, email, name, login, password, address, salary, is_approved) VALUES ('employee', ?, ?, ?, ?, NULL, ?, ?)", 
	    		employee.email, employee.name, employee.login, employee.password, employee.salary, employee.isApproved);
    }
    
    @Override
    @Transactional
    public void update(Employee employee){
    	jdbcTemplate.update("UPDATE person SET email = ?, name = ?, login = ?, salary = ?, is_approved = ? WHERE id = ?",
    			employee.email, employee.name, employee.login, employee.salary, employee.isApproved, employee.id);
    }
    
    @Override
    @Transactional
    public void delete(Employee employee){
	    jdbcTemplate.update("DELETE FROM person WHERE ID = ?", employee.id);
    }
}
