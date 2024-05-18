package com.example.lab8.upd;

import java.io.IOException;
import java.net.*;
import java.util.Timer;
import java.util.TimerTask;

public class Sender {

    private String host;
    private int port;

    public Sender(String host, int port) {
        this.host = host;
        this.port = port;
    }

    public static void main(String [] args) throws Exception {
        Sender sender = new Sender("localhost", 8080);
        String message = "random text";

        Timer timer = new Timer();
        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                try {
                    sender.sendMessage(message);
                } catch (Exception e) {
                    throw new RuntimeException(e);
                }
            }
        }, 1000, 1000);
    }

    private void sendMessage(String message) throws Exception {
        try {
            byte[] data = message.getBytes();
            InetAddress address = InetAddress.getByName(host);
            DatagramPacket pack = new DatagramPacket(data, data.length, address, port);
            DatagramSocket ds = new DatagramSocket();
            ds.send(pack);
            ds.close();
        } catch (Exception e) {
            throw new Exception(e);
        }
    }
}
