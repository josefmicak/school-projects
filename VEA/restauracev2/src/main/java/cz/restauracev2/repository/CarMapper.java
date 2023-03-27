package cz.restauracev2.repository;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.Car;

public class CarMapper implements RowMapper<Car>{

	@Override
	public Car mapRow(ResultSet rs, int rowNum) throws SQLException {
		Car car = new Car();
		car.setId(rs.getLong("id"));
		car.setName(rs.getString("name"));
		car.setLicencePlate(rs.getString("licence_plate"));
		car.setMileage(rs.getInt("mileage"));
		return car;
	}

}
