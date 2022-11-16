package cz.restauracev2.repository;

import javax.sql.DataSource;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

import javax.annotation.PostConstruct;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import cz.restauracev2.model.CustomDateType;

@Repository
public class CustomDateTypeRepositoryJdbc implements CustomDateTypeRepository {
	
	@Autowired
	private DataSource dataSource;
	@Autowired
	private JdbcTemplate jdbcTemplate;
	
	@PostConstruct
	public void init() {
		try {
			Connection con = dataSource.getConnection();
			try(Statement stm = con.createStatement()){
				stm.execute(
						"CREATE TABLE custom_date_type ("
						+ "id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, "
						+ "day INTEGER, "
						+ "hours INTEGER, "
						+ "miliseconds INTEGER, "
						+ "minutes INTEGER, "
						+ "month INTEGER, "
						+ "seconds INTEGER, "
						+ "year INTEGER);"
					);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	@Override
	public CustomDateType findById(long id) {
		return jdbcTemplate.queryForObject("SELECT * FROM custom_date_type WHERE id = ?", new CustomDateTypeMapper(), id);
	}
	
	@Override
	public CustomDateType findByDeliveryId(long deliveryId) {
		return jdbcTemplate.queryForObject("SELECT * FROM custom_date_type WHERE id = ?", new CustomDateTypeMapper(), deliveryId);
	}
	
    @Override
    @Transactional
    public CustomDateType insert(CustomDateType customDateType){
	    jdbcTemplate.update("INSERT INTO custom_date_type (day, hours, miliseconds, minutes, month, seconds, year) VALUES (?, ?, ?, ?, ?, ?, ?)",
	    		customDateType.day, customDateType.hours, customDateType.miliseconds, customDateType.minutes, customDateType.month, customDateType.seconds, customDateType.year);
	    //retreive highest id
	    CustomDateType customDateTypeMaxId = jdbcTemplate.queryForObject("SELECT TOP 1 * FROM custom_date_type ORDER BY id DESC", new CustomDateTypeMapper());
	    return customDateTypeMaxId;
    }

}