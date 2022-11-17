package cz.restauracev2.security;

import java.util.ArrayList;
import java.util.Collection;
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
		return user.getPassword();
	}

	@Override
	public String getUsername() {
		return user.getLogin();
	}

	@Override
	public boolean isAccountNonExpired() {
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		return true;
	}

	@Override
	public boolean isEnabled() {
		return true;
	}

}
