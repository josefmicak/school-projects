package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;

import cz.restauracev2.model.Person;
import cz.restauracev2.repository.PersonRepository;
import cz.restauracev2.repositoryjdbc.PersonRepositoryJdbc;
import cz.restauracev2.repositoryjpa.PersonRepositoryJpa;
import cz.restauracev2.security.Encoder;

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
	private Encoder encoder;
	
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
	public List<Person> findAllEmployees() {
		return personRepository.findAllEmployees();
	}
	
	@Log
	public List<Person> findAllCustomers() {
		return personRepository.findAllCustomers();
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
		long personCountByLogin = findPersonCountByLogin(person.login);
		if(personCountByLogin > 0) {
			System.out.println("Chyba: uživatele s loginem " + person.login + " nelze přidat. Již existuje jiný uživatel s tímto loginem.");
		}
		else {
			person.setPassword(encoder.passwordEncoder().encode(person.password));
			personRepository.insert(person);
		}
	}
	
	public boolean isUpdateLoginDuplicate(Person person) {
		return personRepository.isUpdateLoginDuplicate(person);
	}
	
	@Log
	public void update(Person person) {
		if(isUpdateLoginDuplicate(person)) {
			System.out.println("Chyba: uživateli nelze nastavit login " + person.login + ". Již existuje jiný uživatel s tímto loginem.");
		}
		else {
			personRepository.update(person);
		}
	}
	
	@Log
	public void delete(Person person) {
		personRepository.delete(person);
	}
}