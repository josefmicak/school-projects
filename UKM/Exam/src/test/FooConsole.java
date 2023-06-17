package test;

import java.util.Scanner;

public class FooConsole {

	public static void main(String[] args) {
		Calculator calculator = new Calculator();
		Scanner sc = new Scanner(System.in);
		System.out.println("Enter operator.");
		char op = sc.next().charAt(0);
		double operand1 = 0.;
		double operand2 = 0.;
		System.out.println("Enter first operand");
		operand1 = sc.nextDouble();
		System.out.println("Enter second operand.");
		operand2 = sc.nextDouble();
		System.out.println("result is" + calculator.doOperation(op, operand1, operand2));
	}
}
