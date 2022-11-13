package cz.restauracev2.repository;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Person;

@Repository
public class CustomerRepositoryJpa implements CustomerRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Customer> findAll() {
	   	return entityManager.createQuery("SELECT c FROM Customer c WHERE c.isApproved = 1", Customer.class).getResultList();
   }
   
   @Override
   public Customer findById(long id) {
	   return entityManager.find(Customer.class, id);
   }
	
   @Override
   @Transactional
   public void insert(Customer customer){
	   entityManager.persist(customer);
   }
   
   @Override
   @Transactional
   public void update(Customer customer){
	   entityManager.persist(customer);
   }
   
   @Override
   @Transactional
   public void delete(Customer customer){
	   entityManager.remove(customer);
   }
}
