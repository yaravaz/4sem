package by.it.programmer;

import by.it.Worker;
public abstract class Programmer implements Worker {

    public String getFIO() {
        return FIO;
    }

    public void setFIO(String FIO) {
        this.FIO = FIO;
    }

    public String FIO;

    @Override
    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    public double salary;

    public Programmer(){    }

    public Programmer(String fio, double salary){
        FIO = fio;
        this.salary = salary;
    }

    public void work(){
        System.out.println("Программист работает");
    }

}
