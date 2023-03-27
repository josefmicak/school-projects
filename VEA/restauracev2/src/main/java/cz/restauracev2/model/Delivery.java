package cz.restauracev2.model;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;

@Entity
public class Delivery {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name="employee")
    private Employee employee;
    
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name="customer")
    private Customer customer;
    
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name="car")
    private Car car;
    
    public Delivery() {  	
    }
    
    public Delivery(Employee employee, Customer customer, Car car,  double price) {
		super();
		this.employee = employee;
		this.customer = customer;
		this.car = car;
		this.price = price;
	}

	@OneToOne(fetch = FetchType.EAGER, cascade=CascadeType.ALL)
    @JoinColumn(name="creationDate")
    public CustomDateType creationDate;
    
    public double price;
    
    public long getId() {
        return id;
    }
    
    public void setId(long id) {
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
    
    public Car getCar() {
        return car;
    }
    
    public void setCar(Car car) {
        this.car = car;
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
    
    @Override
    public String toString() {
        return "Delivery: ID = " + id + ", employee name = " + employee.getName() + ", customer name = " + customer.getName() + 
        		", car name: " + car.getName() + ", creation date: " + creationDate + ", price: " + price + " CZK";
    }
}