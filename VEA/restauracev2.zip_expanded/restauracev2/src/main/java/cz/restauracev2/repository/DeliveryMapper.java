package cz.restauracev2.repository;

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
		delivery.setDeliveryId(rs.getLong("id"));
		
		delivery.setPrice(rs.getLong("price"));
		
		CustomDateType customDateType = new CustomDateType();
		customDateType.setCustomDateTypeId(rs.getInt("creation_date"));
		delivery.creationDate = customDateType;
		
		Employee employee = new Employee();
		employee.id = rs.getLong("employee");
		delivery.employee = employee;
		
		Customer customer = new Customer();
		customer.id = rs.getLong("customer");
		delivery.customer = customer;
		
		Car car = new Car();
		car.id = rs.getLong("car");
		delivery.car = car;
		return delivery;
	}

}
