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
	   	return entityManager.createQuery("select e from Person e", Person.class).getResultList();
   }
   
   @Override
   public Person findById(long id) {
	   return entityManager.find(Person.class, id);
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