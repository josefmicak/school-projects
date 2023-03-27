package cz.restauracev2.repository;

import java.util.List;

import cz.restauracev2.model.Car;

public interface CarRepository {
	List<Car> findAll();
	
	Car findById(long id);
	
	void insert(Car car);
	
	void update(Car car);
	
	void delete(Car car);
}