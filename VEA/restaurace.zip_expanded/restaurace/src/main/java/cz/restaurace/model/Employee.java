package cz.restaurace.model;

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
public class Employee {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    
    @NotBlank(message = "Name is mandatory")
    public String name;
    
    @NotBlank(message = "Email is mandatory")
    public String email;
    
    @OneToMany (mappedBy="employee", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    public List<Delivery> deliveries; 
    
    public long getEmployeeId() {
        return id;
    }
    public void setEmployeeId(long id) {
        this.id = id;
    }
    public String getEmployeeName() {
        return name;
    }
    public void setEmployeeName(String name) {
        this.name = name;
    }
    public String getEmployeeEmail() {
        return email;
    }
    public void setEmployeeEmail(String email) {
        this.email = email;
    }
}