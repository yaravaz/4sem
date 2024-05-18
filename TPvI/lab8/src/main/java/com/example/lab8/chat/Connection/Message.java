package com.example.lab8.chat.Connection;

import java.io.Serializable;
import java.util.Set;

public class Message implements Serializable {
    private MessageType messageType;
    private String messageText;
    private Set<String> userList;

    public Message(MessageType typeMessage, String textMessage) {
        this.messageText = textMessage;
        this.messageType = typeMessage;
        this.userList = null;
    }

    public Message(MessageType typeMessage, Set<String> userList) {
        this.messageType = typeMessage;
        this.messageText = null;
        this.userList = userList;
    }

    public Message(MessageType typeMessage) {
        this.messageType = typeMessage;
        this.messageText = null;
        this.userList = null;
    }

    public MessageType getMessageType() {
        return messageType;
    }

    public Set<String> getUserList() {
        return userList;
    }

    public String getMessageText() {
        return messageText;
    }

}
