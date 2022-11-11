package cz.restauracev2.repository;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.Customer;

public class CustomerMapper implements RowMapper<Customer>{

	@Override
	public Customer mapRow(ResultSet rs, int rowNum) throws SQLException {
		Customer customer = new Customer();
		customer.setId(rs.getLong("id"));
		customer.setName(rs.getString("name"));
		customer.setEmail(rs.getString("email"));
		customer.setAddress(rs.getString("address"));
		return customer;
	}

}
