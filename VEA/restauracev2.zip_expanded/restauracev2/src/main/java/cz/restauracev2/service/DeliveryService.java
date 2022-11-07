package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;
import cz.restauracev2.model.Delivery;
import cz.restauracev2.repository.DeliveryRepository;
import cz.restauracev2.repository.DeliveryRepositoryJdbc;
import cz.restauracev2.repository.DeliveryRepositoryJpa;

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
		return deliveryRepository.findEmployeeDeliveries(employeeId);
	}
	
	@Log
	List<Delivery> findCustomerDeliveries(long customerId){
		return deliveryRepository.findCustomerDeliveries(customerId);
	}
	
	@Log
	public Delivery findById(long id) {
		return deliveryRepository.findById(id);
	}

	@Log
	public void insert(Delivery delivery) {
		deliveryRepository.insert(delivery);
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
		deliveryRepository.deleteByCustomerId(customerId);
	}
	
	@Log
	public void deleteByEmployeeId(long employeeId) {
		deliveryRepository.deleteByEmployeeId(employeeId);
	}
}
