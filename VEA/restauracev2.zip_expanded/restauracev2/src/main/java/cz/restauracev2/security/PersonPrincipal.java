package cz.restauracev2.security;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import cz.restauracev2.model.Person;

public class PersonPrincipal implements UserDetails {
	
	private Person user; 
	
	public PersonPrincipal(Person user) {
		super();
		this.user = user;
	}

	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		List<GrantedAuthority> authorities = new ArrayList<>();
		if(!user.getIsApproved()) {
			authorities.add(new SimpleGrantedAuthority("UNAPPROVED"));
		}
		else {
			if(user.getDiscriminatorValue().equals("employee")) {
				authorities.add(new SimpleGrantedAuthority("ADMIN"));
			}
			else if(user.getDiscriminatorValue().equals("customer")) {
				authorities.add(new SimpleGrantedAuthority("USER"));
			}
		}
		return authorities;
	}
	
	public long getUserId() {
		return user.getId();
	}

	@Override
	public String getPassword() {
		// TODO Auto-generated method stub
		return user.getPassword();
	}

	@Override
	public String getUsername() {
		// TODO Auto-generated method stub
		return user.getLogin();
	}

	@Override
	public boolean isAccountNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isEnabled() {
		// TODO Auto-generated method stub
		return true;
	}

}
