package cz.restauracev2.repository;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;

public class EmployeeMapper implements RowMapper<Employee>{

	@Override
	public Employee mapRow(ResultSet rs, int rowNum) throws SQLException {
		Employee employee = new Employee();
		employee.setId(rs.getLong("id"));
		employee.setName(rs.getString("name"));
		employee.setEmail(rs.getString("email"));
		employee.setSalary(rs.getDouble("salary"));
		return employee;
	}

}
