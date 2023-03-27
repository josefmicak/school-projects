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
import cz.restauracev2.model.Car;

@Repository
public class CarRepositoryJdbc implements CarRepository {
	
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
						"CREATE TABLE car ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "name VARCHAR(255), "
						+ "licence_plate VARCHAR(255), "
						+ "mileage INTEGER);"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public List<Car> findAll() {
		List<Car> cars = jdbcTemplate.query("SELECT * FROM car", new CarMapper());
		for(Car car : cars){
			List<Delivery> deliveries = deliveryRepositoryJdbc.findCarDeliveries(car.id);
			car.deliveries = deliveries;
		}
		return cars;
    }
	
	@Override
	public Car findById(long id) {
		Car car = jdbcTemplate.queryForObject("SELECT * FROM car WHERE id = ?", new CarMapper(), id);
		List<Delivery> deliveries = deliveryRepositoryJdbc.findCarDeliveries(id);
		car.deliveries = deliveries;
		return car;
	}
	
	@Override
    public void insert(Car car){
		jdbcTemplate.update("INSERT INTO car (name, licence_plate, mileage) VALUES (?, ?, ?)", car.name, car.licencePlate, car.mileage);	
    }
    
	@Override
    public void update(Car car){
		jdbcTemplate.update("UPDATE car SET name = ?, licence_plate = ?, mileage = ? WHERE id = ?", car.name, car.licencePlate, car.mileage, car.id);	
    }
    
	@Override
    public void delete(Car car){
    	jdbcTemplate.update("DELETE FROM car WHERE ID = ?", car.id);
    }
}