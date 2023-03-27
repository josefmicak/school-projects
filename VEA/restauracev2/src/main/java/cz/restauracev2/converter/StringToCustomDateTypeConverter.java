package cz.restauracev2.converter;

import org.springframework.context.annotation.Configuration;
import org.springframework.core.convert.converter.Converter;
import org.springframework.format.FormatterRegistry;
import org.springframework.stereotype.Component;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

import cz.restauracev2.model.CustomDateType;

@Component
public class StringToCustomDateTypeConverter implements Converter<String, CustomDateType> {
    @Override
    public CustomDateType convert(String dateTime) {
        String[] splitByT = dateTime.split("T");
        String[] dateValues = splitByT[0].split("-");
        String[] splitByDot = splitByT[1].split("\\.");
        String[] timeValues = splitByDot[0].split(":");
        
        return new CustomDateType(
          Integer.parseInt(dateValues[0]), 
          Integer.parseInt(dateValues[1]),
          Integer.parseInt(dateValues[2]),
          Integer.parseInt(timeValues[0]),
          Integer.parseInt(timeValues[1]),
          Integer.parseInt(timeValues[2]),
          Integer.parseInt(splitByDot[1]));
    }
    
    @Configuration
    public class WebConfig implements WebMvcConfigurer {

        @Override
        public void addFormatters(FormatterRegistry registry) {
            registry.addConverter(new StringToCustomDateTypeConverter());
        }
    }
	
}