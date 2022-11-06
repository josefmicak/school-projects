package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.model.Customer;
import cz.restauracev2.repository.CustomerRepository;
import cz.restauracev2.repository.CustomerRepositoryJdbc;
import cz.restauracev2.repository.CustomerRepositoryJpa;

@Service
public class CustomerService {

	private CustomerRepository customerRepository;
	@Autowired
	private CustomerRepositoryJpa customerRepositoryJpa;
	@Autowired
	private CustomerRepositoryJdbc customerRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	
	@Autowired
	public void setCustomerRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.customerRepository = customerRepositoryJpa;
				break;
			case "jdbc":
				this.customerRepository = customerRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	public List<Customer> findAll() {
		return customerRepository.findAll();
	}
	
	public Customer findById(long id) {
		return customerRepository.findById(id);
	}

	public void insert(Customer customer) {
		customerRepository.insert(customer);
	}
	
	public void update(Customer customer) {
		customerRepository.update(customer);
	}
	
	public void delete(Customer customer) {
		customerRepository.delete(customer);
	}


}