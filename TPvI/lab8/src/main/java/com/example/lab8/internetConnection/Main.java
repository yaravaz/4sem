package com.example.lab8.internetConnection;

import java.net.*;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Main {
    public static void main(String [] args) throws Exception {

        URL oracle = new URL("https://www.oracle.com/");
        BufferedReader in = new BufferedReader(new InputStreamReader(oracle.openStream()));

        String inputLine;
        while ((inputLine = in.readLine()) != null){
            System.out.println(inputLine);
        }
        in.close();

        String image="https://i.insider.com/5fd008fc240ebd00126bdd35?width=1000&format=jpeg&auto=webp";
        URL url = new URL(image);
        InputStream input = url.openStream();
        Path path = Paths.get("D:\\images\\Starship.jpeg");

        Files.copy(input, path);
    }
}
