package cz.restauracev2.repository;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Delivery;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Car;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Customer;

@Repository
public class DeliveryRepositoryJpa implements DeliveryRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Delivery> findAll() {
	   	return entityManager.createQuery("select d from Delivery d", Delivery.class).getResultList();
   }
   
   @Override
   public Delivery findById(long id) {
	   return entityManager.find(Delivery.class, id);
   }
   
   @Override
   public Employee findEmployeeId(long id) {
	   return null;//TODO
   }
   
   @Override
   public Customer findCustomerId(long id) {
	   return null;//TODO
   }
   
   @Override
   public Car findCarId(long carId) {
	   return null;//TODO
   }
    
   @Override
   public CustomDateType findCustomDateType(long id) {
	   return null;//TODO
   }
   
   @Override
   public Employee findByEmployeeId(long employeeId) {
	   return null;//TODO
   }
   
   @Override
   public Customer findByCustomerId(long customerId) {
	   return null;//TODO
   }
   
   @Override
   public Car findByCarId(long carId) {
	   return null;//TODO
   }
    
	@Override
	public List<Delivery> findEmployeeDeliveries(long employeeId) {
		return null;//TODO
   }
	
	@Override
	public List<Delivery> findCustomerDeliveries(long customerId) {
		return null;//TODO
   }
	
	@Override
	public List<Delivery> findPersonDeliveries(long personId, String personType) {
		return null;//TODO
   }
	
	@Override
	public List<Delivery> findCarDeliveries(long carId) {
		return null;//TODO
   }
	
   @Override
   @Transactional
   public void insert(Delivery delivery){
	   entityManager.persist(delivery);
   }
   
   @Override
   @Transactional
   public void update(Delivery delivery){
	   entityManager.merge(delivery);
   }
   
   @Override
   @Transactional
   public void delete(Delivery delivery){
	   entityManager.remove(delivery);
   }
   
   @Override
   @Transactional
   public void deleteByCustomerId(long customerId) {
	   
   }
   
   @Override
   @Transactional
   public void deleteByEmployeeId(long employeeId) {
	   
   }
   
   @Override
   @Transactional
   public void deleteByCarId(long carId) {
	   
   }
}
