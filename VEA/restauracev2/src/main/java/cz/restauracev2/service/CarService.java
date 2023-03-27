package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;

import cz.restauracev2.model.Car;
import cz.restauracev2.repository.CarRepository;
import cz.restauracev2.repositoryjdbc.CarRepositoryJdbc;
import cz.restauracev2.repositoryjpa.CarRepositoryJpa;

@Service
public class CarService {

	private CarRepository carRepository;
	@Autowired
	private CarRepositoryJpa carRepositoryJpa;
	@Autowired
	private CarRepositoryJdbc carRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	
	@Autowired
	public void setCarRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.carRepository = carRepositoryJpa;
				break;
			case "jdbc":
				this.carRepository = carRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	@Log
	public List<Car> findAll() {
		return carRepository.findAll();
	}
	
	@Log
	public Car findById(long id) {
		return carRepository.findById(id);
	}

	@Log
	public void insert(Car car) {
		carRepository.insert(car);
	}
	
	@Log
	public void update(Car car) {
		carRepository.update(car);
	}
	
	@Log
	public void delete(Car car) {
		carRepository.delete(car);
	}
}