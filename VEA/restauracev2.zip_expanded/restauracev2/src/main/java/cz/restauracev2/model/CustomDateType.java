package cz.restauracev2.model;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;

@Entity
public class CustomDateType {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private long id;
    
	public int year;
	public int month;
	public int day;
	public int hours;
	public int minutes;
	public int seconds;
	public int miliseconds;
	
	public CustomDateType() {
		
	}
	
	public long getCustomDateTypeId() {
		return this.id;
	}
	
	public void setCustomDateTypeId(long id) {
		this.id = id;
	}
	
	public CustomDateType(int year, int month, int day, int hours, int minutes, int seconds, int miliseconds) {
		this.year = year;
		this.month = month;
		this.day = day;
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.miliseconds = miliseconds;
	}
	
	public String toString() {
		return padLeftZeros(String.valueOf(day), 2) + "." + padLeftZeros(String.valueOf(month), 2) + "." + String.valueOf(year) + " " + 
				padLeftZeros(String.valueOf(hours), 2) + ":" + padLeftZeros(String.valueOf(minutes), 2) + ":" + padLeftZeros(String.valueOf(seconds), 2);
	}
	
	public String padLeftZeros(String inputString, int length) {
	    if (inputString.length() >= length) {
	        return inputString;
	    }
	    StringBuilder sb = new StringBuilder();
	    while (sb.length() < length - inputString.length()) {
	        sb.append('0');
	    }
	    sb.append(inputString);

	    return sb.toString();
	}
}