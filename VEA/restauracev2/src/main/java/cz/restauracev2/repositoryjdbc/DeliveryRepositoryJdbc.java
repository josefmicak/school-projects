package cz.restauracev2.repositoryjdbc;

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

import cz.restauracev2.mapper.CarMapper;
import cz.restauracev2.mapper.CustomDateTypeMapper;
import cz.restauracev2.mapper.PersonMapper;
import cz.restauracev2.mapper.DeliveryMapper;
import cz.restauracev2.model.Car;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.repository.DeliveryRepository;

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
			
			long employeeId = delivery.getEmployee().getId();
			delivery.setEmployee(findByEmployeeId(employeeId));
			
			long customerId = delivery.getCustomer().getId();
			delivery.setCustomer(findByCustomerId(customerId));
			
			long carId = delivery.getCar().getId();
			delivery.setCar(findByCarId(carId));
		}
		return deliveries;
    }
	
	@Override
	public Delivery findById(long id) {
		return jdbcTemplate.queryForObject("SELECT * FROM delivery WHERE id = ?", new DeliveryMapper(), id);
	}
	
	//Get employee whose ID we know
	public Employee findByEmployeeId(long employeeId) {
		Employee employee = (Employee)jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new PersonMapper(), employeeId);
		return employee;
	}
	
	//Get employee whose ID we don't know yet
	public Employee findEmployeeId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT employee AS e FROM delivery WHERE id = ?", id);
		long employeeId = (long)map.get("e");
		return findByEmployeeId(employeeId);
	}
	
	public CustomDateType findCustomDateType(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT creation_date AS c FROM delivery WHERE id = ?", id);
		long customDateTypeId = (long)map.get("c");
		CustomDateType customDateType = jdbcTemplate.queryForObject("SELECT * FROM custom_date_type WHERE id = ?", new CustomDateTypeMapper(), customDateTypeId);
		return customDateType;
	}
	
	//Get customer whose ID we know
	public Customer findByCustomerId(long customerId) {
		Customer customer = (Customer)jdbcTemplate.queryForObject("SELECT * FROM person WHERE id = ?", new PersonMapper(), customerId);
		return customer;
	}
	
	//Get customer whose ID we don't know yet
	public Customer findCustomerId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT customer AS c FROM delivery WHERE id = ?", id);
		long customerId = (long)map.get("c");
		return findByCustomerId(customerId);
	}
	
	//Get car whose ID we know
	public Car findByCarId(long carId) {
		Car car = jdbcTemplate.queryForObject("SELECT * FROM car WHERE id = ?", new CarMapper(), carId);
		return car;
	}
	
	//Get car whose ID we don't know yet
	public Car findCarId(long id) {
		Map<String, Object> map = jdbcTemplate.queryForMap("SELECT car AS c FROM delivery WHERE id = ?", id);
		long carId = (long)map.get("c");
		return findByCarId(carId);
	}
	
	public List<Delivery> findEmployeeDeliveries(long employeeId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE employee = ?", new DeliveryMapper(), employeeId);
		for(Delivery delivery : deliveries) {
			
			Customer customer = findCustomerId(delivery.getId());
			delivery.setCustomer(customer);
			
			Car car = findCarId(delivery.getId());
			delivery.setCar(car);
			
			CustomDateType customDateType = findCustomDateType(delivery.getId());
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
	public List<Delivery> findCustomerDeliveries(long customerId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE customer = ?", new DeliveryMapper(), customerId);
		for(Delivery delivery : deliveries) {
			
			Employee employee = findEmployeeId(delivery.getId());
			delivery.setEmployee(employee);
			
			Car car = findCarId(delivery.getId());
			delivery.setCar(car);
			
			CustomDateType customDateType = findCustomDateType(delivery.getId());
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
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
			
			Employee employee = findEmployeeId(delivery.getId());
			delivery.setEmployee(employee);
			
			Car car = findCarId(delivery.getId());
			delivery.setCar(car);
			
			CustomDateType customDateType = findCustomDateType(delivery.getId());
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
	public List<Delivery> findCarDeliveries(long carId) {
		List<Delivery> deliveries = jdbcTemplate.query("SELECT * FROM delivery WHERE car = ?", new DeliveryMapper(), carId);
		for(Delivery delivery : deliveries) {
			
			Employee employee = findEmployeeId(delivery.getId());
			delivery.setEmployee(employee);
			
			Customer customer = findCustomerId(delivery.getId());
			delivery.setCustomer(customer);
			
			CustomDateType customDateType = findCustomDateType(delivery.getId());
			delivery.creationDate = customDateType;
		}
		return deliveries;
    }
	
    @Override
    @Transactional
    public void insert(Delivery delivery, CustomDateType customDateType){
        CustomDateType customDateTypeInserted = customDateTypeRepositoryJdbc.insert(customDateType);
        delivery.creationDate = customDateTypeInserted;
        
	    jdbcTemplate.update("INSERT INTO delivery (employee, customer, car, creation_date, price) VALUES (?, ?, ?, ?, ?)", 
	    		delivery.getEmployee().getId(), delivery.getCustomer().getId(), delivery.getCar().getId(), delivery.creationDate.getCustomDateTypeId(), delivery.price);
    }
    
    @Override
    @Transactional
    public void update(Delivery delivery){
    	jdbcTemplate.update("UPDATE delivery SET price = ?, customer = ?, employee = ?, car = ? WHERE id = ?", 
    			delivery.price, delivery.getCustomer().getId(), delivery.getEmployee().getId(), delivery.getCar().getId(), delivery.getId());
    }
    
    @Override
    @Transactional
    public void delete(Delivery delivery){
    	CustomDateType customDateType = findCustomDateType(delivery.getId());
	    jdbcTemplate.update("DELETE FROM delivery WHERE id = ?", delivery.getId());
	    
	    //in case we are using JDBC, this now redundant data doesn't get removed automatically
	    jdbcTemplate.update("DELETE FROM custom_date_type WHERE id = ?", customDateType.getCustomDateTypeId());
    }
    
    @Transactional
    public void deleteByCustomerId(long customerId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE customer = ?", customerId);
    }
    
    @Transactional
    public void deleteByEmployeeId(long employeeId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE employee = ?", employeeId);
    }
    
    @Transactional
    public void deleteByCarId(long carId){
	    jdbcTemplate.update("DELETE FROM delivery WHERE car = ?", carId);
    }
}