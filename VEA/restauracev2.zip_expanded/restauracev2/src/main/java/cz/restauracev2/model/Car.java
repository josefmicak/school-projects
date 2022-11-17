package cz.restauracev2.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
public class Car {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    
    @JsonIgnore
    @OneToMany (mappedBy="car", fetch = FetchType.EAGER, cascade=CascadeType.REMOVE)
    private List<Delivery> deliveries; 
    
    private String name;
    
    private String licencePlate;
    
    private int mileage;
    
    public Car() {}   
    
    public Car(String name, String licencePlate, int mileage) {
		super();
		this.name = name;
		this.licencePlate = licencePlate;
		this.mileage = mileage;
	}

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
    
    public String getLicencePlate() {
        return licencePlate;
    }
    
    public void setLicencePlate(String licencePlate) {
        this.licencePlate = licencePlate;
    }
    
    public int getMileage() {
        return mileage;
    }
    
    public void setMileage(int mileage) {
        this.mileage = mileage;
    }
    
    public List<Delivery> getDeliveries() {
        return deliveries;
    }
    
    public void setDeliveries(List<Delivery> deliveries) {
        this.deliveries = deliveries;
    }
    
    @Override
    public String toString() {
        return "Car: ID = " + id + ", name = " + name + ", licence plate = " + licencePlate + ", mileage = " + mileage + " km";
    }
}