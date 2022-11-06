package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.validation.constraints.NotBlank;

@Entity
public class Customer {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    
    @NotBlank(message = "Name is mandatory")
    public String name;
    
    @NotBlank(message = "Email is mandatory")
    public String email;
    
    @OneToMany (mappedBy="customer", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    public List<Delivery> deliveries; 
    
    public long getCustomerId() {
        return id;
    }
    public void setCustomerId(long id) {
        this.id = id;
    }
    public String getCustomerName() {
        return name;
    }
    public void setCustomerName(String name) {
        this.name = name;
    }
    public String getCustomerEmail() {
        return email;
    }
    public void setCustomerEmail(String email) {
        this.email = email;
    }
}