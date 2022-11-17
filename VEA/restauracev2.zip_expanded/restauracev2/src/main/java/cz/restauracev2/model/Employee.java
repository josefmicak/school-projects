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
	public double salary;
	
	@JsonIgnore
    @OneToMany (mappedBy="employee", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    public List<Delivery> deliveries; 
    
    public Employee() {  	
    }
    
    public Employee(String name, String email, String login, String password, boolean isApproved, double salary) {
		super();
		this.name = name;
		this.email = email;
		this.login = login;
		this.password = password;
		this.isApproved = isApproved;
		this.salary = salary;
	}
    
	public double getSalary() {
        return salary;
    }
    public void setSalary(double salary) {
        this.salary = salary;
    }
    
    @Override
    public String toString() {
        return "Employee: ID = " + id + ", name = " + name + ", email = " + email + ", salary = " + salary + " Kč" + ", is approved = " + isApproved;
    }
}