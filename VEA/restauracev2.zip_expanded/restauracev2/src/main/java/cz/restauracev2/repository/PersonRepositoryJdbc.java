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

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;

@Repository
public class PersonRepositoryJdbc implements PersonRepository {
	
	@Autowired
	private DataSource dataSource;
	@Autowired
	private JdbcTemplate jdbcTemplate;
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE person ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "person_type VARCHAR(255), "
						+ "email VARCHAR(255), "
						+ "name VARCHAR(255), "
						+ "salary FLOAT, "
						+ "address VARCHAR(255));"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	
	//@Override
	public List<Person> findAll() {
		List<Person> persons = jdbcTemplate.query("SELECT * FROM person", new PersonMapper());
		return persons;
    }
	
	//@Override
	public Person findById(long id) {
		Person person = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new PersonMapper(), id);
		return person;
	}
	
    public void insert(Person person){
    	if(person.getDiscriminatorValue().equals("employee")) {
    		Employee employee = (Employee) person;
    		jdbcTemplate.update("INSERT INTO person (person_type, email, name, address, salary) VALUES ('employee', ?, ?, NULL, ?)", employee.email, employee.name, employee.salary);
    	}
    	else {
    		Customer customer = (Customer) person;
    		jdbcTemplate.update("INSERT INTO person (person_type, email, name, address, salary) VALUES ('customer', ?, ?, ?, NULL)", customer.email, customer.name, customer.address);
    	}
    	
    }
    
    public void update(Person person){
    	if(person.getDiscriminatorValue().equals("employee")) {
    		Employee employee = (Employee) person;
    		jdbcTemplate.update("UPDATE person SET email = ?, name = ?, salary = ? WHERE id = ?", employee.email, employee.name, employee.salary, employee.id);
    	}
    	else {
    		Customer customer = (Customer) person;
    		jdbcTemplate.update("UPDATE person SET email = ?, name = ?, address = ? WHERE id = ?", customer.email, customer.name, customer.address, customer.id);
    	}
    }
    
    public void delete(Person person){
    	jdbcTemplate.update("DELETE FROM person WHERE ID = ?", person.id);
    }
}