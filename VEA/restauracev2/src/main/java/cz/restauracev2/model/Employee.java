package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@DiscriminatorValue("employee")
public class Employee extends Person{
	private double salary;
	
	@JsonIgnore
    @OneToMany (mappedBy="employee", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    private List<Delivery> deliveries; 
    
    public Employee() {  	
    }
    
    public Employee(String name, String email, String login, String password, boolean isApproved, double salary) {
		super();
		this.setName(name);
		this.setEmail(email);
		this.setLogin(login);
		this.setPassword(password);
		this.setIsApproved(isApproved);
		this.salary = salary;
	}
    
	public double getSalary() {
        return salary;
    }
	
    public void setSalary(double salary) {
        this.salary = salary;
    }
    
    public List<Delivery> getDeliveries() {
		return deliveries;
	}
    
	public void setDeliveries(List<Delivery> deliveries) {
		this.deliveries = deliveries;
	}

	@Override
    public String toString() {
		return "Employee: ID = " + getId() + ", name = " + getName() + ", email: " + getEmail() + ", salary: " + getSalary() + ", is approved = " + getIsApproved();
    }
}