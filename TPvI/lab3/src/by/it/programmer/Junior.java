package by.it.programmer;

import by.it.Worker;

public class Junior extends Programmer {

    public Junior(){
        super();
    }
    public Junior(String fio, double salary){
        super(fio,salary);
    }

    public Position getPosition() {
        return position;
    }

    private final Position position = Position.JUNIOR_CASE;

    @Override
    public void work(){
        System.out.println("Интересно, чем занимает джун");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
}
