package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;

import cz.restauracev2.model.Person;
import cz.restauracev2.repository.PersonRepository;
import cz.restauracev2.repository.PersonRepositoryJdbc;
import cz.restauracev2.repository.PersonRepositoryJpa;

@Service
public class PersonService {

	private PersonRepository personRepository;
	@Autowired
	private PersonRepositoryJpa personRepositoryJpa;
	@Autowired
	private PersonRepositoryJdbc personRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	
	@Autowired
	public void setPersonRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.personRepository = personRepositoryJpa;
				break;
			case "jdbc":
				this.personRepository = personRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	@Log
	public List<Person> findAll() {
		return personRepository.findAll();
	}
	
	@Log
	public List<Person> findAllRegistrations() {
		return personRepository.findAllRegistrations();
	}
	
	@Log
	public Person findById(long id) {
		return personRepository.findById(id);
	}
	
	@Log
	public long findPersonCountByLogin(String login) {
		return personRepository.findPersonCountByLogin(login);
	}
	
	@Log
	public Person findByLogin(String login) throws Exception {
		return personRepository.findByLogin(login);
	}

	@Log
	public void insert(Person person) {
		personRepository.insert(person);
	}
	
	@Log
	public void update(Person person) {
		personRepository.update(person);
	}
	
	@Log
	public void delete(Person person) {
		personRepository.delete(person);
	}
}