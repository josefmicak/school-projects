package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.Person;

public interface PersonRepository {
	List<Person> findAll();
	
	Person findById(long id);
	
	void insert(Person person);
	
	void update(Person person);
	
	void delete(Person person);
}
