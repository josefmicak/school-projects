package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.Customer;

public interface CustomerRepository {
	List<Customer> findAll();
	
	Customer findById(long id);
		
	void insert(Customer customer);
	
	void update(Customer customer);
	
	void delete(Customer customer);
}
