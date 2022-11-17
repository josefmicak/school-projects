package cz.restauracev2.service;

import java.time.LocalDateTime;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.convert.ConversionService;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.repository.DeliveryRepository;
import cz.restauracev2.repositoryjdbc.DeliveryRepositoryJdbc;
import cz.restauracev2.repositoryjpa.DeliveryRepositoryJpa;

@Service
public class DeliveryService {

	private DeliveryRepository deliveryRepository;
	@Autowired
	private DeliveryRepositoryJpa deliveryRepositoryJpa;
	@Autowired
	private DeliveryRepositoryJdbc deliveryRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	@Autowired
	ConversionService conversionService;
	
	
	@Autowired
	public void setDeliveryRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.deliveryRepository = deliveryRepositoryJpa;
				break;
			case "jdbc":
				this.deliveryRepository = deliveryRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	@Log
	public List<Delivery> findAll() {
		return deliveryRepository.findAll();
	}
	
	@Log
	List<Delivery> findEmployeeDeliveries(long employeeId){
		return deliveryRepositoryJdbc.findEmployeeDeliveries(employeeId);
	}
	
	@Log
	List<Delivery> findCustomerDeliveries(long customerId){
		return deliveryRepositoryJdbc.findCustomerDeliveries(customerId);
	}
	
	@Log
	public Delivery findById(long id) {
		return deliveryRepository.findById(id);
	}

	@Log
	public void insert(Delivery delivery) {
		LocalDateTime currentDateTime = LocalDateTime.now();
        String currentDateTimeString = String.valueOf(currentDateTime);
        CustomDateType customDateType = conversionService.convert(currentDateTimeString, CustomDateType.class);
		
		deliveryRepository.insert(delivery, customDateType);
	}
	
	@Log
	public void update(Delivery delivery) {
		deliveryRepository.update(delivery);
	}
	
	@Log
	public void delete(Delivery delivery) {
		deliveryRepository.delete(delivery);
	}

	@Log
	public void deleteByCustomerId(long customerId) {
		deliveryRepositoryJdbc.deleteByCustomerId(customerId);
	}
	
	@Log
	public void deleteByEmployeeId(long employeeId) {
		deliveryRepositoryJdbc.deleteByEmployeeId(employeeId);
	}
	
	@Log
	public void deleteByCarId(long carId) {
		deliveryRepositoryJdbc.deleteByCarId(carId);
	}
}
