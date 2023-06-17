import java.util.Scanner;

public class HelloWorldRun{
    public static void main(String[] args){
        System.out.println("Hello world");
        //don't close command line after the program is run
        Scanner scanner = new Scanner(System.in); 
        scanner.nextLine();
    }
}