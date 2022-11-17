package cz.restauracev2.repositoryjpa;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Car;
import cz.restauracev2.repository.CarRepository;

@Repository
public class CarRepositoryJpa implements CarRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Car> findAll() {
	   List<Car> cars =  entityManager.createQuery("select c from Car c", Car.class).getResultList();
	   return cars;
   }
   
   @Override
   public Car findById(long id) {
	   return entityManager.find(Car.class, id);
   }
	
   @Override
   @Transactional
   public void insert(Car car){
	   entityManager.persist(car);
   }
   
   @Override
   @Transactional
   public void update(Car car){
	   entityManager.merge(car);
   }
   
   @Override
   @Transactional
   public void delete(Car car){
	   entityManager.remove(car);
   }
}