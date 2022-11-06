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
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE employee ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "email VARCHAR(255), "
						+ "name VARCHAR(255));"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	
	@Override
	public List<Employee> findAll() {
		List<Employee> employees = jdbcTemplate.query("SELECT * FROM employee", new EmployeeMapper());
		for(Employee employee : employees){
			List<Delivery> deliveries = deliveryRepositoryJdbc.findEmployeeDeliveries(employee.id);
			employee.deliveries = deliveries;
		}
		return employees;
    }
	
	@Override
	public Employee findById(long id) {
		Employee employee = jdbcTemplate.queryForObject("SELECT * FROM employee WHERE id = ?", new EmployeeMapper(), id);
		List<Delivery> deliveries = deliveryRepositoryJdbc.findEmployeeDeliveries(id);
		employee.deliveries = deliveries;
		return employee;
	}
	
    @Override
    @Transactional
    public void insert(Employee employee){
	    jdbcTemplate.update("INSERT INTO employee (email, name) VALUES (?, ?)", employee.email, employee.name);
    }
    
    @Override
    @Transactional
    public void update(Employee employee){
    	jdbcTemplate.update("UPDATE employee SET email = ?, name = ? WHERE id = ?", employee.email, employee.name, employee.id);
    }
    
    @Override
    @Transactional
    public void delete(Employee employee){
	    jdbcTemplate.update("DELETE FROM EMPLOYEE WHERE ID = ?", employee.id);
    }
}
