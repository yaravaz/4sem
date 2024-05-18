package com.example.lab8.chat.Client;

import java.util.HashSet;
import java.util.Set;

public class ModelGuiClient {
    private Set<String> users = new HashSet<>();

    protected Set<String> getUsers() {
        return users;
    }

    protected void addUser(String nameUser) {
        users.add(nameUser);
    }

    protected void removeUser(String nameUser) {
        users.remove(nameUser);
    }

    protected void setUser(Set<String> users) {
        this.users = users;
    }
}