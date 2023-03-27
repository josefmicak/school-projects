package cz.restauracev2.mapper;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.Car;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;

public class DeliveryMapper implements RowMapper<Delivery>{
	
	@Override
	public Delivery mapRow(ResultSet rs, int rowNum) throws SQLException {
		Delivery delivery = new Delivery();
		delivery.setId(rs.getLong("id"));
		
		delivery.setPrice(rs.getLong("price"));
		
		CustomDateType customDateType = new CustomDateType();
		customDateType.setCustomDateTypeId(rs.getInt("creation_date"));
		delivery.creationDate = customDateType;
		
		Employee employee = new Employee();
		employee.setId(rs.getLong("employee"));
		delivery.setEmployee(employee);
		
		Customer customer = new Customer();
		customer.setId(rs.getLong("customer"));
		delivery.setCustomer(customer);
		
		Car car = new Car();
		car.setId(rs.getLong("car"));
		delivery.setCar(car);
		return delivery;
	}

}
