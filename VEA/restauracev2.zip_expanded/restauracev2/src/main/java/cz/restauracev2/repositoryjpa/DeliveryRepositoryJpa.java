package cz.restauracev2.repositoryjpa;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.Delivery;
import cz.restauracev2.repository.DeliveryRepository;
import cz.restauracev2.model.CustomDateType;

@Repository
public class DeliveryRepositoryJpa implements DeliveryRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public List<Delivery> findAll() {
    List<Delivery> deliveries = entityManager.createQuery("select d from Delivery d", Delivery.class).getResultList();
   	return deliveries;
   }
   
   @Override
   public Delivery findById(long id) {
	   Delivery delivery = entityManager.find(Delivery.class, id);
	   return delivery;
   }
	
   @Override
   @Transactional
   public void insert(Delivery delivery, CustomDateType customDateType){
       delivery.creationDate = customDateType;     
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
}
