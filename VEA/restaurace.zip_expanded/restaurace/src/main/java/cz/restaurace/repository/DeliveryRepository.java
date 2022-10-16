package cz.restaurace.repository;

import org.springframework.data.repository.CrudRepository;

import cz.restaurace.model.Delivery;

public interface DeliveryRepository extends CrudRepository<Delivery, Long> {
}