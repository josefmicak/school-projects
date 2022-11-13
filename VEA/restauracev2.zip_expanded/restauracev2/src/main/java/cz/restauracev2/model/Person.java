package cz.restauracev2.model;

import javax.persistence.DiscriminatorColumn;

import javax.persistence.DiscriminatorType;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Transient;

import org.springframework.beans.factory.annotation.Autowired;

import cz.restauracev2.security.Encoder;

@Entity
@Inheritance(strategy = InheritanceType.SINGLE_TABLE)
@DiscriminatorColumn(name="person_type", 
discriminatorType = DiscriminatorType.STRING)
public class Person {
	
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    
    public String name;
    
    public String email;
    
    public String login;
    
    public String password;
    
    public boolean isApproved;
    
    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }
    
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    
    public String getLogin() {
        return login;
    }
    public void setLogin(String login) {
        this.login = login;
    }
    
    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }
    
    public boolean getIsApproved() {
        return isApproved;
    }
    public void setIsApproved(boolean isApproved) {
        this.isApproved = isApproved;
    }
    
    @Transient
    public String getDiscriminatorValue(){
        DiscriminatorValue val = this.getClass().getAnnotation( DiscriminatorValue.class );

        return val == null ? null : val.value();
    }
    
}
