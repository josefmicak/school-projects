package cz.restauracev2.repository;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Employee;

@Repository
public class EmployeeRepositoryJpa implements EmployeeRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Employee> findAll() {
	   	return entityManager.createQuery("select e from Employee e", Employee.class).getResultList();
   }
   
   @Override
   public Employee findById(long id) {
	   return entityManager.find(Employee.class, id);
   }
	
   @Override
   @Transactional
   public void insert(Employee employee){
	   entityManager.persist(employee);
   }
   
   @Override
   @Transactional
   public void update(Employee employee){
	   entityManager.persist(employee);
   }
   
   @Override
   @Transactional
   public void delete(Employee employee){
	   entityManager.remove(employee);
   }
}
