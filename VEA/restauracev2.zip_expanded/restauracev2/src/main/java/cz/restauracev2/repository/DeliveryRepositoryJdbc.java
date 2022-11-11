package cz.restauracev2.repository;

import javax.sql.DataSource;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;
import java.util.Map;

import javax.annotation.PostConstruct;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;

@Repository
public class DeliveryRepositoryJdbc implements DeliveryRepository {
	
	@Autowired
	private DataSource dataSource;
	@Autowired
	private JdbcTemplate jdbcTemplate;
	@Autowired
	CustomDateTypeRepositoryJdbc customDateTypeRepositoryJdbc;
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE delivery ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "employee INTEGER NOT NULL, "
						+ "customer INTEGER NOT NULL, "
						+ "car INTEGER NOT NULL, "
						+ "creation_date INTEGER, "
						+ "price FLOAT);"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	
	@Override
	public List<Delivery> findAll() {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery", new DeliveryMapper());
		for(Delivery delivery : deliveries) {
			long customDateTypeId = delivery.creationDate.getCustomDateTypeId();
			delivery.creationDate = customDateTypeRepositoryJdbc.findByDeliveryId(customDateTypeId);
			
			long employeeId = delivery.employee.id;
			delivery.employee = findByEmployeeId(employeeId);
			
			long customerId = delivery.customer.id;
			delivery.customer = findByCustomerId(customerId);
			
			long carId = delivery.car.id;
			delivery.car = findByCarId(carId);
		}
		return deliveries;
    }
	
	//Get employee whose ID we know
	@Override
	public Employee findByEmployeeId(long employeeId) {
		Employee employee = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new EmployeeMapper(), employeeId);
		return employee;
	}
	
	//Get employee whose ID we don't know yet
	@Override 
	public Employee findEmployeeId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT employee AS e FROM delivery WHERE id = ?", id);
		long employeeId = (long)map.get("e");
		return findByEmployeeId(employeeId);
	}
	
	@Override 
	public CustomDateType findCustomDateType(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT creation_date AS c FROM delivery WHERE id = ?", id);
		long customDateTypeId = (long)map.get("c");
		CustomDateType customDateType = jdbcTemplate.queryForObject("SELECT * FROM custom_date_type WHERE id = ?", new CustomDateTypeMapper(), customDateTypeId);
		return customDateType;
	}
	
	//Get customer whose ID we know
	@Override
	public Customer findByCustomerId(long customerId) {
		Customer customer = jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new CustomerMapper(), customerId);
		return customer;
	}
	
	//Get customer whose ID we don't know yet
	@Override 
	public Customer findCustomerId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT customer AS c FROM delivery WHERE id = ?", id);
		long customerId = (long)map.get("c");
		return findByCustomerId(customerId);
	}
	
	//Get car whose ID we know
	@Override
	public Car findByCarId(long carId) {
		Car car = jdbcTemplate.queryForObject("SELECT * FROM car WHERE id = ?", new CarMapper(), carId);
		return car;
	}
	
	//Get car whose ID we don't know yet
	@Override 
	public Car findCarId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT car AS c FROM delivery WHERE id = ?", id);
		long carId = (long)map.get("c");
		return findByCarId(carId);
	}
   
	@Override
	public Delivery findById(long id) {
		return jdbcTemplate.queryForObject("SELECT * FROM delivery WHERE id = ?", new DeliveryMapper(), id);
	}
	
	@Override
	public List<Delivery> findEmployeeDeliveries(long employeeId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE employee = ?", new DeliveryMapper(), employeeId);
		for(Delivery delivery : deliveries) {
			
			Customer customer = findCustomerId(delivery.id);
			delivery.customer = customer;
			
			Car car = findCarId(delivery.id);
			delivery.car = car;
			
			CustomDateType customDateType = findCustomDateType(delivery.id);
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
	@Override
	public List<Delivery> findCustomerDeliveries(long customerId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE customer = ?", new DeliveryMapper(), customerId);
		for(Delivery delivery : deliveries) {
			
			Employee employee = findEmployeeId(delivery.id);
			delivery.employee = employee;
			
			Car car = findCarId(delivery.id);
			delivery.car = car;
			
			CustomDateType customDateType = findCustomDateType(delivery.id);
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
	@Override
	public List<Delivery> findPersonDeliveries(long personId, String personType) {
		String query = "";
		if(personType.equals("employee")) {
			query = "SELECT * FROM delivery WHERE employee = ?";
		}
		else if(personType.equals("customer")) {
			query = "SELECT * FROM delivery WHERE customer = ?";
		}
		List<Delivery> deliveries = jdbcTemplate.query(query, new DeliveryMapper(), personId);
		for(Delivery delivery : deliveries) {
			
			Employee employee = findEmployeeId(delivery.id);
			delivery.employee = employee;
			
			Car car = findCarId(delivery.id);
			delivery.car = car;
			
			CustomDateType customDateType = findCustomDateType(delivery.id);
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
	@Override
	public List<Delivery> findCarDeliveries(long carId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE car = ?", new DeliveryMapper(), carId);
		for(Delivery delivery : deliveries) {
			
			Employee employee = findEmployeeId(delivery.id);
			delivery.employee = employee;
			
			Customer customer = findCustomerId(delivery.id);
			delivery.customer = customer;
			
			CustomDateType customDateType = findCustomDateType(delivery.id);
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
    @Override
    @Transactional
    public void insert(Delivery delivery){
	    jdbcTemplate.update("INSERT INTO delivery (employee, customer, car, creation_date, price) VALUES (?, ?, ?, ?, ?)", 
	    		delivery.employee.id, delivery.customer.id, delivery.car.id, delivery.creationDate.getCustomDateTypeId(), delivery.price);
    }
    
    @Override
    @Transactional
    public void update(Delivery delivery){
    	jdbcTemplate.update("UPDATE delivery SET price = ?, customer = ?, employee = ?, car = ? WHERE id = ?", 
    			delivery.price, delivery.customer.id, delivery.employee.id, delivery.car.id, delivery.id);
    }
    
    @Override
    @Transactional
    public void delete(Delivery delivery){
    	CustomDateType customDateType = findCustomDateType(delivery.id);
	    jdbcTemplate.update("DELETE FROM delivery WHERE id = ?", delivery.id);
	    
	    //in case we are using JDBC, this now redundant data doesn't get removed automatically
	    jdbcTemplate.update("DELETE FROM custom_date_type WHERE id = ?", customDateType.getCustomDateTypeId());
    }
    
    @Override
    @Transactional
    public void deleteByCustomerId(long customerId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE customer = ?", customerId);
    }
    
    @Override
    @Transactional
    public void deleteByEmployeeId(long employeeId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE employee = ?", employeeId);
    }
    
    @Override
    @Transactional
    public void deleteByCarId(long carId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE car = ?", carId);
    }
}
