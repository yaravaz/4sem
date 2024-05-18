package by.it.head;

import by.it.Worker;
import by.it.programmer.Position;

public class Cto implements Worker {
    public String getFIO() {
        return FIO;
    }

    public void setFIO(String FIO) {
        this.FIO = FIO;
    }

    private String FIO;

    @Override
    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    private double salary;

    public Cto(){
    }
    public Cto(String fio, double salary){
        FIO = fio;
        this.salary = salary;
    }

    public Position getPosition() {
        return position;
    }

    private final Position position = Position.CTO_CASE;

    public void integration(){
        System.out.println("Главный технолог интегрирует новые технологии");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
}
