package test;

/**
 * @version 0.0.1
 * @author koz01
 *
 */
public class Calculator {

	public double doOperation(char operator, double operand1,double operand2) {
		switch(operator) {
			case '+':
				return operand1 + operand2;
				default:
					throw new UnsupportedOperationException(""+operator);
		}
	}
}
