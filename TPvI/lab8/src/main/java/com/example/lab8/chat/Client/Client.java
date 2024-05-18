package com.example.lab8.chat.Client;

import com.example.lab8.chat.Connection.Connection;
import com.example.lab8.chat.Connection.Message;
import com.example.lab8.chat.Connection.MessageType;

import java.io.IOException;
import java.net.Socket;

public class Client {

    private Connection connection;
    private static ModelGuiClient model;
    private static ViewGuiClient gui;
    private volatile boolean isConnect = false;

    public boolean isConnect(){
        return isConnect;
    }
    public void setConnect(boolean connect){
        isConnect = connect;
    }

    public static void main(String [] args) throws IOException {
        Client client = new Client();
        model = new ModelGuiClient();
        gui = new ViewGuiClient(client);
        gui.initFrameClient();
        while(true){
            if(client.isConnect()){
                client.userNameRegistration();
                client.receiveMessage();
                client.setConnect(false);
            }
        }
    }

    protected void connectClient() {
        if (!isConnect) {
            while (true) {
                try {
                    String addressServer = gui.getServerAddressOptionPane();
                    int port = gui.getServerPortOptionPane();
                    Socket socket = new Socket(addressServer, port);
                    connection = new Connection(socket);
                    isConnect = true;
                    gui.addMessage("server: Вы подключились.\n");
                    break;
                } catch (Exception e) {
                    gui.errorDialogWindow("Произошла ошибка! Попробуйте еще раз");
                    break;
                }
            }
        } else gui.errorDialogWindow("Вы уже подключены!");
    }

    protected void userNameRegistration() {
        while (true) {
            try {
                Message message = connection.receive();
                if (message.getMessageType() == MessageType.REQUEST_NAME_USER) {
                    String nameUser = gui.getNameUser();
                    connection.sendMessage(new Message(MessageType.USER_NAME, nameUser));
                }
                if (message.getMessageType() == MessageType.NAME_USED) {
                    gui.errorDialogWindow("Имя занято, введите другое");
                    String nameUser = gui.getNameUser();
                    connection.sendMessage(new Message(MessageType.USER_NAME, nameUser));
                }
                if (message.getMessageType() == MessageType.NAME_ACCEPTED) {
                    gui.addMessage("server: имя принято\n");
                    model.setUser(message.getUserList());
                    break;
                }
            } catch (Exception e) {
                e.printStackTrace();
                gui.errorDialogWindow("Произошла ошибка при регистрации имени. Попробуйте переподключиться");
                try {
                    connection.close();
                    isConnect = false;
                    break;
                } catch (IOException ex) {
                    gui.errorDialogWindow("Ошибка при закрытии соединения");
                }
            }

        }
    }

    protected void sendMessage(String text) {
        try {
            connection.sendMessage(new Message(MessageType.TEXT_MESSAGE, text));
        } catch (Exception e) {
            gui.errorDialogWindow("Ошибка при отправки сообщения");
        }
    }

    protected void receiveMessage() {
        while (isConnect) {
            try {
                Message message = connection.receive();
                if (message.getMessageType() == MessageType.TEXT_MESSAGE) {
                    gui.addMessage(message.getMessageText());
                }
                if (message.getMessageType() == MessageType.USER_ADDED) {
                    model.addUser(message.getMessageText());
                    gui.addMessage(String.format("server: пользователь %s присоединился к чату.\n", message.getMessageText()));
                }
                if (message.getMessageType() == MessageType.REMOVED_USER) {
                    model.removeUser(message.getMessageText());
                    gui.addMessage(String.format("server: пользователь %s покинул чат.\n", message.getMessageText()));
                }
            } catch (Exception e) {
                gui.errorDialogWindow("Ошибка при приеме сообщения от сервера.");
                setConnect(false);
                break;
            }
        }
    }
    protected void disableClient() {
        try {
            if (isConnect) {
                connection.sendMessage(new Message(MessageType.DISABLE_USER));
                model.getUsers().clear();
                isConnect = false;
            } else gui.errorDialogWindow("Вы уже отключены.");
        } catch (Exception e) {
            gui.errorDialogWindow("Сервисное сообщение: произошла ошибка при отключении.");
        }
    }
}
