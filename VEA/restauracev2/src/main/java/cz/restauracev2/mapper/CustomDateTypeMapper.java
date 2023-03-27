package cz.restauracev2.mapper;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.CustomDateType;

public class CustomDateTypeMapper implements RowMapper<CustomDateType>{

	@Override
	public CustomDateType mapRow(ResultSet rs, int rowNum) throws SQLException {
		CustomDateType customDateType = new CustomDateType();
		customDateType.setCustomDateTypeId(rs.getLong("id"));
		customDateType.setDay(rs.getInt("day"));
		customDateType.setHours(rs.getInt("hours"));
		customDateType.setMiliseconds(rs.getInt("miliseconds"));
		customDateType.setMinutes(rs.getInt("minutes"));
		customDateType.setMonth(rs.getInt("month"));
		customDateType.setSeconds(rs.getInt("seconds"));
		customDateType.setYear(rs.getInt("year"));
		return customDateType;
	}

}
