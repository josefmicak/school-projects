package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.OneToMany;

@Entity
//@Component//TODO: delete?
@DiscriminatorValue("employee")
public class Employee extends Person{
	public double salary;
	
    @OneToMany (mappedBy="employee", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    public List<Delivery> deliveries; 
    
    public double getSalary() {
        return salary;
    }
    public void setSalary(double salary) {
        this.salary = salary;
    }
    
    @Override
    public String toString() {
        return "Employee: ID = " + id + ", name = " + name + ", email = " + email + ", salary = " + salary + " Kč";
    }
}