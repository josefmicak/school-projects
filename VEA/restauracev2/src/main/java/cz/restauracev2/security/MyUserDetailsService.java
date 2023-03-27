package cz.restauracev2.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import cz.restauracev2.model.Person;
import cz.restauracev2.service.PersonService; 
@Service
public class MyUserDetailsService implements UserDetailsService {
	
	@Autowired
	private PersonService personService;
	
	@Override
	public UserDetails loadUserByUsername(String login) throws UsernameNotFoundException {
		Person user = new Person();
		try {
			user = personService.findByLogin(login);
		} catch (Exception e) {
			e.printStackTrace();
		}
		if(user==null) {
			throw new UsernameNotFoundException("User not found!");
		}		
		return new PersonPrincipal(user);

	}
}