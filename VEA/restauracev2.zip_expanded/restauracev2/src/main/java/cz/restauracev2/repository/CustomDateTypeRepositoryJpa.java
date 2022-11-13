package cz.restauracev2.repository;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cz.restauracev2.model.CustomDateType;

@Repository
public class CustomDateTypeRepositoryJpa implements CustomDateTypeRepository {
	
   @PersistenceContext
   EntityManager entityManager;
   
   @Override
   public CustomDateType findById(long id) {
	   return entityManager.find(CustomDateType.class, id);
   }
   
   public CustomDateType findByDeliveryId(long deliveryId) {
	   return null;
   }
	
   @Override
   @Transactional
   public CustomDateType insert(CustomDateType customDateType){
	   entityManager.persist(customDateType);
	   return null;//todo
   }
}
