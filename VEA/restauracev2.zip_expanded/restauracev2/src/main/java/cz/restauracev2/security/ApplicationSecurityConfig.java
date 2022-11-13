package cz.restauracev2.security;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.event.EventListener;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.method.configuration.GlobalMethodSecurityConfiguration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.AuthenticationSuccessHandler;
import org.springframework.security.web.util.matcher.AntPathRequestMatcher;

import cz.restauracev2.service.PersonService;
import cz.restauracev2.model.Customer;
import cz.restauracev2.model.Employee;
import cz.restauracev2.model.Person;

@Configuration
@EnableWebSecurity
public class ApplicationSecurityConfig {
	
	@Autowired
	private UserDetailsService userDetailsService;
	
	@Autowired
	private Encoder encoder;
	
	@Autowired
	private PersonService personService;
	
    @PersistenceContext
    EntityManager entityManager;

	@Bean
	public AuthenticationProvider authProvider() {
		
		DaoAuthenticationProvider provider = new DaoAuthenticationProvider();
		
		provider.setUserDetailsService(userDetailsService);
		
		provider.setPasswordEncoder(encoder.passwordEncoder());
		return provider;
	}	
	
	@Bean
	public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
		http
		.csrf().disable()
		.authorizeRequests()
			.antMatchers("/login").permitAll()
			.antMatchers("/register").permitAll()
			.antMatchers("/register/*").permitAll()
			.antMatchers("/js/**").permitAll()
			.antMatchers("/awaiting-approval").hasAuthority("UNAPPROVED")
			.antMatchers("/employeemenu").hasAuthority("ADMIN")
			.antMatchers("/customermenu").hasAnyAuthority("USER","ADMIN")
			.antMatchers("/cars").hasAuthority("ADMIN")
			.antMatchers("/cars/*").hasAuthority("ADMIN")
			.antMatchers("/employees").hasAuthority("ADMIN")
			.antMatchers("/employees/*").hasAuthority("ADMIN")
			.antMatchers("/deliveries").hasAuthority("ADMIN")
			.antMatchers("/deliveries/*").hasAuthority("ADMIN")
			.antMatchers("/persons").hasAuthority("ADMIN")
			.antMatchers("/persons/*").hasAuthority("ADMIN")
			.antMatchers("/customers").hasAuthority("ADMIN")
			.antMatchers("/customers/*").hasAuthority("ADMIN")
			.anyRequest().authenticated()
		.and()
			.formLogin()
			.loginPage("/login").permitAll()
		    .successHandler(new AuthenticationSuccessHandler() {
		         
		        @Override
		        public void onAuthenticationSuccess(HttpServletRequest request, HttpServletResponse response,
		                Authentication authentication) throws IOException, ServletException {
		            UserDetails userDetails = (UserDetails) authentication.getPrincipal();
		            String login = userDetails.getUsername();
		            Person user = new Person();
					try {
						user = personService.findByLogin(login);
					} catch (Exception e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					if(!user.getIsApproved()) {
						response.sendRedirect("/awaitingapproval");
					}
					else {
			            if(user.getDiscriminatorValue().equals("employee")) {
			            	response.sendRedirect("/employeemenu");
			            }
			            else if(user.getDiscriminatorValue().equals("customer")){
			            	response.sendRedirect("/customerdeliveries/" + user.getId());
			            }
					}
		        }
		    })
		.and()
			.exceptionHandling().accessDeniedPage("/accessdenied")
		.and()
			.logout().invalidateHttpSession(true)
			.clearAuthentication(true)
			.logoutRequestMatcher(new AntPathRequestMatcher("/performlogout"))
			.logoutSuccessUrl("/logout").permitAll();

	    return http.build();
	}
	
	/*@Override
	public void configure(WebSecurity web) throws Exception {
	  web.ignoring().antMatchers("/the_js_path/**");
	}*/
	
	@Configuration
	@EnableGlobalMethodSecurity(
	  prePostEnabled = true, 
	  securedEnabled = true, 
	  jsr250Enabled = true)
	public class MethodSecurityConfig 
	  extends GlobalMethodSecurityConfiguration {
	}
	
	@EventListener(ApplicationReadyEvent.class)
	@Transactional
	public void doSomethingAfterStartup() {

		//save();
		
	    System.out.println("hello world, I have just started up");
	}
	
	@Transactional
	public void save() {
		Employee employee = new Employee();
		employee.setPassword(encoder.passwordEncoder().encode("asd"));
		employee.setLogin("asd");
		employee.setName("a a");
		employee.setSalary(2);
		employee.setEmail("email");
		employee.isApproved = true;
		entityManager.persist(employee);
		
		Customer customer = new Customer();
		customer.setPassword(encoder.passwordEncoder().encode("bla"));
		customer.setLogin("bla");
		customer.setName("b b");
		customer.setAddress("address");
		customer.setEmail("email2");
		customer.isApproved = false;
		entityManager.persist(customer);
	}
}