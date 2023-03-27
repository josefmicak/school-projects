package cz.restauracev2.repository;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.RowMapper;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;

public class PersonMapper implements RowMapper<Person>{
	
	//@Autowired
	//DeliveryRepositoryJdbc deliveryRepositoryJdbc;

	@Override
	public Person mapRow(ResultSet rs, int rowNum) throws SQLException {
		Person person;
		if(rs.getString("person_type").equals("employee")) {
			Employee newPerson = new Employee();
			newPerson.setId(rs.getLong("id"));
			newPerson.setName(rs.getString("name"));
			newPerson.setLogin(rs.getString("login"));
			newPerson.setPassword(rs.getString("password"));
			newPerson.setIsApproved(rs.getBoolean("is_approved"));
			newPerson.setEmail(rs.getString("email"));
			newPerson.setSalary(rs.getDouble("salary"));
			
			person = newPerson;
		}
		else {
			Customer newPerson = new Customer();
			newPerson.setId(rs.getLong("id"));
			newPerson.setName(rs.getString("name"));
			newPerson.setLogin(rs.getString("login"));
			newPerson.setPassword(rs.getString("password"));
			newPerson.setIsApproved(rs.getBoolean("is_approved"));
			newPerson.setEmail(rs.getString("email"));
			newPerson.setAddress(rs.getString("address"));
			person = newPerson;
		}
		return person;
	}

}
