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
    //@OneToMany (mappedBy="customer", fetch = FetchType.EAGER)
    public List<Delivery> deliveries; 
    
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