package cz.restauracev2.repository;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;

@Repository
public class PersonRepositoryJpa implements PersonRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Person> findAll() {
	   List<Person> persons = entityManager.createQuery("SELECT p FROM Person p WHERE p.isApproved = 1", Person.class).getResultList();
	   List<Person> newPersons = new ArrayList<Person>();
	   
	   //severing object relations for REST
	   for(Person person : persons) {
		   if(person.getDiscriminatorValue().equals("employee")) {
			   Employee employee = (Employee) person;
			   for(Delivery delivery : employee.deliveries) {
				   delivery.car.deliveries = null;
				   delivery.employee = null;
				   delivery.customer = null;
			   }
			   newPersons.add(employee);
		   }
		   else {
			   Customer customer = (Customer) person;
			   for(Delivery delivery : customer.deliveries) {
				   delivery.car.deliveries = null;
				   delivery.employee = null;
				   delivery.customer = null;
			   }
			   newPersons.add(customer);
		   }
	   }
	   return newPersons;
   }
   
   @Override
   public List<Person> findAllRegistrations() {
	   	return entityManager.createQuery("SELECT p FROM Person p WHERE p.isApproved = 0", Person.class).getResultList();
   }
   
   @Override
   public Person findById(long id) {
	   return entityManager.find(Person.class, id);
   }
   
   @Override
   public long findPersonCountByLogin(String login) {
	   return entityManager.createQuery(
			   "SELECT COUNT(*) FROM Person p WHERE p.login = :login", Long.class).
				  setParameter("login", login).getSingleResult();
   }
   
   @Override
   public Person findByLogin(String login) throws Exception {
	   long personCountByLogin = findPersonCountByLogin(login);
	   if(personCountByLogin == 0) {
		   throw new Exception("Chyba: uživatel neexistuje.");
	   }
	   return entityManager.createQuery(
			   "SELECT p FROM Person p WHERE p.login = :login", Person.class).
				  setParameter("login", login).getSingleResult();
   }
   
   public boolean isUpdateLoginDuplicate(Person person) {
	   long personCountByLogin = findPersonCountByLogin(person.login);
	   if(personCountByLogin == 0) {
		   return false;
	   }
	   if(personCountByLogin > 1) {
		   return true;
	   }
	   
	   Person personByLogin = entityManager.createQuery(
			   "SELECT p FROM Person p WHERE p.login = :login", Person.class).
				  setParameter("login", person.login).getSingleResult();
	   if(person.id != personByLogin.id) {
		   return true;
	   }
	   else {
		   return false;
	   }
   }
	
   @Override
   @Transactional
   public void insert(Person person){
	   entityManager.persist(person);
   }
   
   @Override
   @Transactional
   public void update(Person person){
	   entityManager.merge(person);
   }
   
   @Override
   @Transactional
   public void delete(Person person){
	   entityManager.remove(person);
   }
}