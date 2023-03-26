import java.io.*;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        Thread thread1 = new Thread(() ->
        {
            try {
                Client client = new Client("158.196.145.111", 8000);
                String message;
                BufferedReader consoleInputStream = new BufferedReader(new InputStreamReader(System.in));

                do {
                    message = consoleInputStream.readLine();
                    client.send(message);
                } while (!message.equals("exit"));

            } catch (IOException e) {
                e.printStackTrace();
            }
        });

        Thread thread2 = new Thread(() -> {
            try {
                Server server = new Server(8010);
                server.run();
            } catch (IOException e) {
                e.printStackTrace();
            }
        });

        thread1.start();
        thread2.start();

        thread1.join();
        thread2.join();
    }
}
