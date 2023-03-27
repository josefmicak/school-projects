package cz.restauracev2.logging;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

import java.util.Arrays;

@Aspect
@Component
public class LogAspect {

    @Around("@annotation(log)")
    public Object protect(ProceedingJoinPoint joinPoint, Log log) throws Throwable {
        Logger logger = LoggerFactory.getLogger(joinPoint.getSignature().getDeclaringType());
        logger.info("LOG: Function {}.{}() called with arguments: {}", joinPoint.getSignature().getDeclaringTypeName(),
                joinPoint.getSignature().getName(), Arrays.toString(joinPoint.getArgs()));
        
        Object proceed;
        try {
            proceed = joinPoint.proceed();
        } catch (Throwable e) {
            logger.info("LOG: Function {}.{}() failed with exception message: {}", joinPoint.getSignature().getDeclaringTypeName(), 
            		joinPoint.getSignature().getName(), e.getMessage());
            throw e;
        }
        
        logger.info("LOG: Function {}.{}() finished with result: {}", joinPoint.getSignature().getDeclaringTypeName(),
                joinPoint.getSignature().getName(), proceed);
        return proceed;
    }
}