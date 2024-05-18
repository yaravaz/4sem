package by.it.programmer;

public class Lead extends Programmer{

    public Lead(){
        super();
    }
    public Lead(String fio, double salary){
        super(fio,salary);
    }

    public Position getPosition() {
        return position;
    }

    private final Position position = Position.LEAD_CASE;

    @Override
    public void work(){
        System.out.println("Дело серьёзное, работает лид");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
}
