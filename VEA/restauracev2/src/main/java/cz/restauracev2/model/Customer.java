package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@DiscriminatorValue("customer")
public class Customer extends Person{
	private String address;
	
	@JsonIgnore
	@OneToMany (mappedBy="customer", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    private List<Delivery> deliveries; 
	
	public Customer() {  	
    }
	
    public Customer(String name, String email, String login, String password, boolean isApproved, String address) {
		super();
		this.setName(name);
		this.setEmail(email);
		this.setLogin(login);
		this.setPassword(password);
		this.setIsApproved(isApproved);
		this.address = address;
	}
    
    public String getAddress() {
        return address;
    }
    
    public void setAddress(String address) {
        this.address = address;
    }
    
    public List<Delivery> getDeliveries() {
		return deliveries;
	}

	public void setDeliveries(List<Delivery> deliveries) {
		this.deliveries = deliveries;
	}

    @Override
    public String toString() {
        return "Customer: ID = " + getId() + ", name = " + getName() + ", email: " + getEmail() + ", address: " + getAddress() + ", is approved = " + getIsApproved();
    }  
}