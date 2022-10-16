package cz.restaurace.model;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotBlank;

@Entity
public class Employee {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public long id;
    
    @NotBlank(message = "Name is mandatory")
    public String name;
    
    @NotBlank(message = "Email is mandatory")
    public String email;
    
    public long getEmployeeId() {
        return id;
    }
    public void setId(long id) {
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

    // standard constructors / setters / getters / toString
}