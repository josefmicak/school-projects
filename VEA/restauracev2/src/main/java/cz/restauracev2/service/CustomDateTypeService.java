package cz.restauracev2.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import cz.restauracev2.logging.Log;
import cz.restauracev2.model.CustomDateType;
import cz.restauracev2.repository.CustomDateTypeRepository;
import cz.restauracev2.repositoryjdbc.CustomDateTypeRepositoryJdbc;
import cz.restauracev2.repositoryjpa.CustomDateTypeRepositoryJpa;

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
	
	@Log
	public CustomDateType findById(long id) {
		return customDateTypeRepository.findById(id);
	}
	
	@Log
	public CustomDateType findByDeliveryId(long deliveryId) {
		return customDateTypeRepository.findByDeliveryId(deliveryId);
	}

	@Log
	public CustomDateType insert(CustomDateType customDateType) {
		return customDateTypeRepository.insert(customDateType);
	}

}