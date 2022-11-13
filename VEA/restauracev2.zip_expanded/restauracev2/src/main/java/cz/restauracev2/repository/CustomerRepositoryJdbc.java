package cz.restauracev2.repository;

import javax.sql.DataSource;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;

@Repository
public class CustomerRepositoryJdbc implements CustomerRepository {
	
	@Autowired
	private DataSource dataSource;
	@Autowired
	private JdbcTemplate jdbcTemplate;
	@Autowired
	DeliveryRepositoryJdbc deliveryRepositoryJdbc;
	
	/*@PostConstruct
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
	}*/

	
	@Override
	public List<Customer> findAll() {
		List<Customer> customers = jdbcTemplate.query("SELECT * FROM person WHERE person_type = 'customer' AND is_approved = 1", new CustomerMapper());
		for(Customer customer : customers){
			List<Delivery> deliveries = deliveryRepositoryJdbc.findCustomerDeliveries(customer.id);
			customer.deliveries = deliveries;
		}
		return customers;
    }
   
	@Override
	public Customer findById(long id) {
		Customer customer = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new CustomerMapper(), id);
		
		List<Delivery> deliveries = deliveryRepositoryJdbc.findCustomerDeliveries(id);
		customer.deliveries = deliveries;
		
		return customer;
	}
	
    @Override
    @Transactional
    public void insert(Customer customer){
	    jdbcTemplate.update("INSERT INTO person (person_type, email, name, login, password, address, salary, is_approved) VALUES ('customer', ?, ?, ?, ?, ?, NULL, ?)", 
	    		customer.email, customer.name, customer.login, customer.password, customer.address, customer.isApproved);
    }
    
    @Override
    @Transactional
    public void update(Customer customer){
    	jdbcTemplate.update("UPDATE person SET email = ?, name = ?, login = ?, address = ?, is_approved = ? WHERE id = ?",
    			customer.email, customer.name, customer.login, customer.address, customer.isApproved, customer.id);
    }
    
    @Override
    @Transactional
    public void delete(Customer customer){
	    jdbcTemplate.update("DELETE FROM person WHERE id = ?", customer.id);
    }
}