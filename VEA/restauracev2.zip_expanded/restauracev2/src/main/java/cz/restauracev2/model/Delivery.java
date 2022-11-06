package cz.restauracev2.model;

import java.time.LocalDateTime;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
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
    
    @OneToOne(fetch = FetchType.EAGER, cascade=CascadeType.ALL)
    @JoinColumn(name="creationDate")
    public CustomDateType creationDate;
    
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

    public CustomDateType getCreationDate() {
        return creationDate;
    }
    public void setCreationDate(CustomDateType creationDate) {
        this.creationDate = creationDate;
    }
    
    public double getPrice() {
        return price;
    }
    public void setPrice(double price) {
        this.price = price;
    }
}