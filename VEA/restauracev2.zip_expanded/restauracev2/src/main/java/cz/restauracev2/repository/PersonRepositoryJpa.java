package cz.restauracev2.repository;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Person;

@Repository
public class PersonRepositoryJpa implements PersonRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Person> findAll() {
	   	return entityManager.createQuery("SELECT p FROM Person p WHERE p.isApproved = 1", Person.class).getResultList();
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
	
   @Override
   @Transactional
   public void insert(Person person){
	   System.out.println("test1");
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