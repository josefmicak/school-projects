package cz.restauracev2.repository;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.CustomDateType;

public class CustomDateTypeMapper implements RowMapper<CustomDateType>{

	@Override
	public CustomDateType mapRow(ResultSet rs, int rowNum) throws SQLException {
		CustomDateType customDateType = new CustomDateType();
		customDateType.setCustomDateTypeId(rs.getLong("id"));
		customDateType.day = rs.getInt("day");
		customDateType.hours = rs.getInt("hours");
		customDateType.miliseconds = rs.getInt("miliseconds");
		customDateType.minutes = rs.getInt("minutes");
		customDateType.month = rs.getInt("month");
		customDateType.seconds = rs.getInt("seconds");
		customDateType.year = rs.getInt("year");
		/*customer.setCustomerId(rs.getLong("id"));
		customer.setCustomerName(rs.getString("name"));
		customer.setCustomerEmail(rs.getString("email"));*/
		return customDateType;
	}

}
