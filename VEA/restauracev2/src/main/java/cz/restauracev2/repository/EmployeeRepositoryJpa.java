package cz.restauracev2.repository;

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
public class EmployeeRepositoryJpa implements EmployeeRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Employee> findAll() {
	   List<Employee> employees = entityManager.createQuery("SELECT e FROM Employee e WHERE e.isApproved = 1", Employee.class).getResultList();
	   //severing object relations for REST
	   for(Employee employee : employees) {
		   for(Delivery delivery : employee.deliveries) {
			   delivery.car.deliveries = null;
			   delivery.employee = null;
			   delivery.customer.deliveries = null;
		   }
	   }
	   return employees;
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
