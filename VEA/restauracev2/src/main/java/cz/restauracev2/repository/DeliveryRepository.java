package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Delivery;

public interface DeliveryRepository {
	List<Delivery> findAll();
	
	Delivery findById(long id);
	
	void insert(Delivery delivery, CustomDateType customDateType);
	
	void update(Delivery delivery);
	
	void delete(Delivery delivery);
}
