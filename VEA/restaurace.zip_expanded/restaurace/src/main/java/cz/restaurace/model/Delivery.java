package cz.restaurace.model;

import java.time.LocalDateTime;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.validation.constraints.NotBlank;

@Entity
public class Delivery {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name="employee")
    public Employee employee;
    
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name="customer")
    public Customer customer;
    
    public LocalDateTime creationDate;
    
    public double price;
    
    public long getDeliveryId() {
        return id;
    }
    public void setDeliveryId(long id) {
        this.id = id;
    }
    
    public Employee getEmployee() {
        return employee;
    }
    public void setEmployee(Employee employee) {
        this.employee = employee;
    }

    public Customer getCustomer() {
        return customer;
    }
    public void setCustomer(Customer customer) {
        this.customer = customer;
    }
    
    public LocalDateTime getCreationDate() {
        return creationDate;
    }
    public void setCreationDate(LocalDateTime creationDate) {
        this.creationDate = creationDate;
    }
    
    public double getPrice() {
        return price;
    }
    public void setPrice(double price) {
        this.price = price;
    }
}