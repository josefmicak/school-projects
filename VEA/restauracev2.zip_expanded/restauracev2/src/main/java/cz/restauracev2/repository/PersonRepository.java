package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.Person;

public interface PersonRepository {
	List<Person> findAll();
	
	List<Person> findAllRegistrations();
	
	Person findById(long id);
	
	long findPersonCountByLogin(String login);
	
	Person findByLogin(String login) throws Exception;
	
	void insert(Person person);
	
	void update(Person person);
	
	void delete(Person person);
}
