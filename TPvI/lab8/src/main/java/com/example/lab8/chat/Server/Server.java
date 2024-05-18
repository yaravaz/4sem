package com.example.lab8.chat.Server;

import com.example.lab8.chat.Connection.Connection;
import com.example.lab8.chat.Connection.Message;
import com.example.lab8.chat.Connection.MessageType;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Server {

    private ServerSocket serverSocket;
    private static ViewGuiServer gui;
    private static ModelGuiServer model;
    private static volatile boolean isServerStart = false;

    public static void main(String [] args) throws IOException {
        Server server = new Server();
        gui = new ViewGuiServer(server);
        model = new ModelGuiServer();
        gui.initFrameServer();
        while (true) {
            if (isServerStart) {
                server.acceptServer();
                isServerStart = false;
            }
        }
    }

    protected void startServer(int port) {
        try {
            serverSocket = new ServerSocket(port);
            isServerStart = true;
            gui.refreshDialogWindow("Сервер запущен.\n");
        } catch (Exception e) {
            gui.refreshDialogWindow("Не удалось запустить сервер.\n");
        }
    }

    protected void stopServer() {
        try {
            if (serverSocket != null && !serverSocket.isClosed()) {
                for (Map.Entry<String, Connection> user : model.getAllUsers().entrySet()) {
                    user.getValue().close();
                }
                serverSocket.close();
                model.getAllUsers().clear();
                gui.refreshDialogWindow("Сервер остановлен.\n");
            } else gui.refreshDialogWindow("Сервер не запущен - останавливать нечего!\n");
        } catch (Exception e) {
            gui.refreshDialogWindow("Остановить сервер не удалось.\n");
        }
    }

    protected void acceptServer() {
        while (true) {
            try {
                Socket socket = serverSocket.accept();
                new ServerThread(socket).start();
            } catch (Exception e) {
                gui.refreshDialogWindow("Связь с сервером потеряна.\n");
                break;
            }
        }
    }

    protected void sendMessageInToChat(Message message) {
        for (Map.Entry<String, Connection> user : model.getAllUsers().entrySet()) {
            try {
                user.getValue().sendMessage(message);
            } catch (Exception e) {
                gui.refreshDialogWindow("Ошибка отправки сообщения всем пользователям!\n");
            }
        }
    }

    private class ServerThread extends Thread {
        private Socket socket;

        public ServerThread(Socket socket) {
            this.socket = socket;
        }

        private String requestAndAddingUser(Connection connection) {
            while (true) {
                try {
                    connection.sendMessage(new Message(MessageType.REQUEST_NAME_USER));
                    Message responseMessage = connection.receive();
                    String userName = responseMessage.getMessageText();
                    if (responseMessage.getMessageType() == MessageType.USER_NAME && userName != null && !userName.isEmpty() && !model.getAllUsers().containsKey(userName)) {
                        model.addUser(userName, connection);
                        Set<String> listUsers = new HashSet<>();
                        for (Map.Entry<String, Connection> users : model.getAllUsers().entrySet()) {
                            listUsers.add(users.getKey());
                        }
                        connection.sendMessage(new Message(MessageType.NAME_ACCEPTED, listUsers));
                        sendMessageInToChat(new Message(MessageType.USER_ADDED, userName));
                        return userName;
                    }
                    else connection.sendMessage(new Message(MessageType.NAME_USED));
                } catch (Exception e) {
                    gui.refreshDialogWindow("Возникла ошибка при запросе и добавлении нового пользователя\n");
                }
            }
        }

        private void messagingBetweenUsers(Connection connection, String userName) {
            while (true) {
                try {
                    Message message = connection.receive();
                    if (message.getMessageType() == MessageType.TEXT_MESSAGE) {
                        String textMessage = String.format("%s: %s\n", userName, message.getMessageText());
                        sendMessageInToChat(new Message(MessageType.TEXT_MESSAGE, textMessage));
                    }
                    if (message.getMessageType() == MessageType.DISABLE_USER) {
                        sendMessageInToChat(new Message(MessageType.REMOVED_USER, userName));
                        model.removeUser(userName);
                        connection.close();
                        gui.refreshDialogWindow(String.format("Пользователь %s отключился.\n", socket.getRemoteSocketAddress()));
                        break;
                    }
                } catch (Exception e) {
                    gui.refreshDialogWindow(String.format("Произошла ошибка при рассылке сообщения от пользователя %s, либо отключился!\n", userName));
                    break;
                }
            }
        }

        @Override
        public void run() {
            gui.refreshDialogWindow(String.format("Подключился новый пользователь %s.\n", socket.getRemoteSocketAddress()));
            try {
                Connection connection = new Connection(socket);
                String nameUser = requestAndAddingUser(connection);
                messagingBetweenUsers(connection, nameUser);
            } catch (Exception e) {
                gui.refreshDialogWindow(String.format("Произошла ошибка при рассылке сообщения от пользователя!\n"));
            }
        }
    }
}


