package cz.restauracev2.repository;


import cz.restauracev2.model.CustomDateType;

public interface CustomDateTypeRepository {
	
	CustomDateType findById(long id);
	
	CustomDateType findByDeliveryId(long deliveryId);
	
	CustomDateType insert(CustomDateType customDateType);
}
