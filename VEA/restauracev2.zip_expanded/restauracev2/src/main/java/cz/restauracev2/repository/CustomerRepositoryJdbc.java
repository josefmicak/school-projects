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
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE customer ("
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
	public List<Customer> findAll() {
		List<Customer> customers = jdbcTemplate.query("SELECT * FROM customer", new CustomerMapper());
		for(Customer customer : customers){
			List<Delivery> deliveries = deliveryRepositoryJdbc.findCustomerDeliveries(customer.id);
			customer.deliveries = deliveries;
		}
		return customers;
    }
   
	@Override
	public Customer findById(long id) {
		Customer customer = jdbcTemplate.queryForObject("SELECT * FROM customer WHERE id = ?", new CustomerMapper(), id);
		
		List<Delivery> deliveries = deliveryRepositoryJdbc.findCustomerDeliveries(id);
		customer.deliveries = deliveries;
		
		return customer;
	}
	
    @Override
    @Transactional
    public void insert(Customer customer){
	    jdbcTemplate.update("INSERT INTO customer (email, name) VALUES (?, ?)", customer.email, customer.name);
    }
    
    @Override
    @Transactional
    public void update(Customer customer){
    	jdbcTemplate.update("UPDATE customer SET email = ?, name = ? WHERE id = ?", customer.email, customer.name, customer.id);
    }
    
    @Override
    @Transactional
    public void delete(Customer customer){
	    jdbcTemplate.update("DELETE FROM customer WHERE id = ?", customer.id);
    }
}