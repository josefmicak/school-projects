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
	@Autowired
	DeliveryRepositoryJdbc deliveryRepositoryJdbc;
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE person ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "person_type VARCHAR(255), "
						+ "login VARCHAR(255), "
						+ "password VARCHAR(255), "
						+ "email VARCHAR(255), "
						+ "name VARCHAR(255), "
						+ "salary FLOAT, "
						+ "is_approved BIT, "
						+ "address VARCHAR(255));"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	
	@Override
	public List<Person> findAll() {
		List<Person> persons = jdbcTemplate.query("SELECT * FROM person WHERE is_approved = 1", new PersonMapper());
		List<Person> newPersons = new ArrayList<Person>();
		
	   for(Person person : persons) {
		   if(person.getDiscriminatorValue().equals("employee")) {
			   Employee employee = (Employee) person;
			   employee.deliveries = deliveryRepositoryJdbc.findEmployeeDeliveries(employee.id);
			   newPersons.add(employee);
		   }
		   else {
			   Customer customer = (Customer) person;
			   customer.deliveries = deliveryRepositoryJdbc.findCustomerDeliveries(customer.id);
			   newPersons.add(customer);
		   }
	   }
		return newPersons;
    }
	
	@Override
	public List<Person> findAllRegistrations() {
		List<Person> persons = jdbcTemplate.query("SELECT * FROM person WHERE is_approved = 0", new PersonMapper());
		return persons;
    }
	
	@Override
	public Person findById(long id) {
		Person person = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new PersonMapper(), id);
		return person;
	}
	
	@Override
	public long findPersonCountByLogin(String login) {
		long personCountByLogin = jdbcTemplate.queryForObject("SELECT COUNT(*) FROM person WHERE login = ?", long.class, login);
		return personCountByLogin;
	}
	
	@Override
	public boolean isUpdateLoginDuplicate(Person person) {
		long personCountByLogin = findPersonCountByLogin(person.login);
	   if(personCountByLogin == 0) {
		   return false;
	   }
	   if(personCountByLogin > 1) {
		   return true;
	   }
	   
	   Person personByLogin = findByLogin(person.login);
	   if(person.id != personByLogin.id) {
		   return true;
	   }
	   else {
		   return false;
	   }
	}
	
	@Override
	public Person findByLogin(String login) {
		Person person = jdbcTemplate.queryForObject("SELECT * FROM person WHERE login = ?", new PersonMapper(), login);
		return person;
	}
	
	@Override
    public void insert(Person person){
    	if(person.getDiscriminatorValue().equals("employee")) {
    		Employee employee = (Employee) person;
    		jdbcTemplate.update("INSERT INTO person (person_type, email, name, login, password, address, salary, is_approved) VALUES ('employee', ?, ?, ?, ?, NULL, ?, ?)", 
    				employee.email, employee.name, employee.login, employee.password, employee.salary, employee.isApproved);
    	}
    	else {
    		Customer customer = (Customer) person;
    		jdbcTemplate.update("INSERT INTO person (person_type, email, name, login, password, address, salary, is_approved) VALUES ('customer', ?, ?, ?, ?, ?, NULL, ?)",
    				customer.email, customer.name, customer.login, customer.password, customer.address, customer.isApproved);
    	}
    	
    }
    
	@Override
    public void update(Person person){
    	if(person.getDiscriminatorValue().equals("employee")) {
    		Employee employee = (Employee) person;
    		jdbcTemplate.update("UPDATE person SET email = ?, name = ?, login = ?, salary = ?, is_approved = ? WHERE id = ?", 
    				employee.email, employee.name, employee.login, employee.salary, employee.isApproved, employee.id);
    	}
    	else {
    		Customer customer = (Customer) person;
    		jdbcTemplate.update("UPDATE person SET email = ?, name = ?, login = ?, address = ?, is_approved = ? WHERE id = ?", 
    				customer.email, customer.name, customer.login, customer.address, customer.isApproved, customer.id);
    	}
    }
    
	@Override
    public void delete(Person person){
    	jdbcTemplate.update("DELETE FROM person WHERE ID = ?", person.id);
    }
}