package com.example.lab8.upd;

import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class Client {
    public static void main(String [] args) throws Exception {
        try{
            DatagramSocket ds = new DatagramSocket(8080);

            while (true){
                DatagramPacket pack = new DatagramPacket(new byte[11], 11);
                ds.receive(pack);
                System.out.println(new String(pack.getData()));
            }
        } catch (Exception e) {
            throw new Exception(e);
        }
    }
}
