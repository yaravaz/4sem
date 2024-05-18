package com.example.lab8.chat.Server;

import com.example.lab8.chat.Connection.Connection;

import java.util.HashMap;
import java.util.Map;

public class ModelGuiServer {
    private Map<String, Connection> allUsers = new HashMap<>();


    protected Map<String, Connection> getAllUsers() {
        return allUsers;
    }

    protected void addUser(String nameUser, Connection connection) {
        allUsers.put(nameUser, connection);
    }

    protected void removeUser(String nameUser) {
        allUsers.remove(nameUser);
    }

}