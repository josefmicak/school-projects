import java.io.*;
import java.net.*;

public class Server implements Runnable {
    private int port;

    public Server(int port) throws SocketException {
        this.port = port;
    }

    @Override
    public void run() {
        try {
            DatagramSocket s=new DatagramSocket(port);
            DatagramPacket p;
            String msg;

            do {
                p = new DatagramPacket(new byte[512], 512);
                s.receive(p);

                byte[] bytes = p.getData();

                StringBuilder ip = new StringBuilder();
                int delka = bytes[8];
                for(int i = 0; i < 4; i++)
                {
                    int n = 0xFF & bytes[i];
                    if(ip.length() > 0)
                    {
                        ip.append(".");
                    }
                    ip.append(n);
                }

                msg = new String(p.getData(),9,p.getLength());
                System.out.println("DG from " + ip + ":" + p.getPort() + " > " + msg + " (" +  delka + ")");
                p.setData(msg.toUpperCase().getBytes());
                p.setLength(msg.length());
                s.send(p);
            } while (!msg.equals("down"));

            s.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
