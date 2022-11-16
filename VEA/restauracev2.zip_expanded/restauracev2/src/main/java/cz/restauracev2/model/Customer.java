package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.OneToMany;

@Entity
@DiscriminatorValue("customer")
public class Customer extends Person{
	public String address;
	
	@OneToMany (mappedBy="customer", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    public List<Delivery> deliveries; 
	
    public Customer() {  	
    }
	
    public Customer(String name, String email, String login, String password, boolean isApproved, String address) {
		super();
		this.name = name;
		this.email = email;
		this.login = login;
		this.password = password;
		this.isApproved = isApproved;
		this.address = address;
	}
    
    public String getAddress() {
        return address;
    }
    public void setAddress(String address) {
        this.address = address;
    }
    
    @Override
    public String toString() {
        return "Customer: ID = " + id + ", name = " + name + ", email: " + email + ", address: " + address + ", is approved = " + isApproved;
    }
    
    
}