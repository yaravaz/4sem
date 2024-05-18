package by.it.manager;

import by.it.Worker;
import by.it.programmer.Position;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "developmanager")
public class DevelopManager implements Worker {

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

    public DevelopManager(){
    }
    public DevelopManager(String fio, double salary){
        FIO = fio;
        this.salary = salary;
    }

    public Position getPosition() {
        return position;
    }

    private final Position position = Position.DEVELOPMENT_MANAGER;

    public void advise(){
        System.out.println("Менеждер разработки что-то посоветовал");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
}
