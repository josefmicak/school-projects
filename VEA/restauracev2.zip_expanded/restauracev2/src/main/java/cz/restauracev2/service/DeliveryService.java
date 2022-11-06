package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

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
	
	public List<Delivery> findAll() {
		return deliveryRepository.findAll();
	}
	
	List<Delivery> findEmployeeDeliveries(long employeeId){
		return deliveryRepository.findEmployeeDeliveries(employeeId);
	}
	
	List<Delivery> findCustomerDeliveries(long customerId){
		return deliveryRepository.findCustomerDeliveries(customerId);
	}
	
	public Delivery findById(long id) {
		return deliveryRepository.findById(id);
	}

	public void insert(Delivery delivery) {
		deliveryRepository.insert(delivery);
	}
	
	public void update(Delivery delivery) {
		deliveryRepository.update(delivery);
	}
	
	public void delete(Delivery delivery) {
		deliveryRepository.delete(delivery);
	}

	public void deleteByCustomerId(long customerId) {
		deliveryRepository.deleteByCustomerId(customerId);
	}
	
	public void deleteByEmployeeId(long employeeId) {
		deliveryRepository.deleteByEmployeeId(employeeId);
	}
}
