package cz.restauracev2.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.repository.CustomDateTypeRepository;
import cz.restauracev2.repository.CustomDateTypeRepositoryJdbc;
import cz.restauracev2.repository.CustomDateTypeRepositoryJpa;

@Service
public class CustomDateTypeService {

	private CustomDateTypeRepository customDateTypeRepository;
	@Autowired
	private CustomDateTypeRepositoryJpa customDateTypeRepositoryJpa;
	@Autowired
	private CustomDateTypeRepositoryJdbc customDateTypeRepositoryJdbc;
	@Value("${customdatasource}")
	private String customDataSource;
	
	@Autowired
	public void setCustomDateTypeRepository() throws Exception {
		switch(customDataSource)
		{
			case "jpa":
				this.customDateTypeRepository = customDateTypeRepositoryJpa;
				break;
			case "jdbc":
				this.customDateTypeRepository = customDateTypeRepositoryJdbc;
				break;
			default:
				throw new Exception("Chyba: neplatný datový zdroj.");
		}
	}
	
	public CustomDateType findById(long id) {
		return customDateTypeRepository.findById(id);
	}
	
	public CustomDateType findByDeliveryId(long deliveryId) {
		return customDateTypeRepository.findByDeliveryId(deliveryId);
	}

	public CustomDateType insert(CustomDateType customDateType) {
		return customDateTypeRepository.insert(customDateType);
	}

}
