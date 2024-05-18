package by.it.programmer;

import java.util.Comparator;


public class Middle extends Programmer{

    public Middle(){
        super();
    }
    public Middle(String fio, double salary){
        super(fio,salary);
    }

    public Position getPosition() {
        return position;
    }

    private final Position position = Position.MIDDLE_CASE;

    @Override
    public void work(){
        System.out.println("Мидл что-то делает");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
}
