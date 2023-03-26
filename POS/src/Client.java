import java.net.*;
import java.io.*;

public class Client {
    private String host;
    private int port;

    public Client(String host, int port) throws IOException
    {
        this.host = host;
        this.port = port;
    }

    public void send(String l)
    {
        try {
            Socket s = new Socket(host, port);
            BufferedWriter os = new BufferedWriter(new OutputStreamWriter(s.getOutputStream()));
            os.write(l);
            os.newLine();
            os.flush();
            s.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}