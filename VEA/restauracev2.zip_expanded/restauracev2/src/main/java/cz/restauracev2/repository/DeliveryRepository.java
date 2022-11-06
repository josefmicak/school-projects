package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;

public interface DeliveryRepository {
	List<Delivery> findAll();
	
	List<Delivery> findEmployeeDeliveries(long employeeId);
	
	List<Delivery> findCustomerDeliveries(long customerId);
	
	Delivery findById(long id);
	
	Employee findEmployeeId(long id);
	
	Customer findCustomerId(long id);
	
	Employee findByEmployeeId(long employeeId);
	
	Customer findByCustomerId(long customerId);
	
	CustomDateType findCustomDateType(long id);
	
	void insert(Delivery delivery);
	
	void update(Delivery delivery);
	
	void delete(Delivery delivery);
	
	void deleteByCustomerId(long customerId);
	
	void deleteByEmployeeId(long employeeId);
}