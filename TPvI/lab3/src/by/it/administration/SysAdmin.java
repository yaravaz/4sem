package by.it.administration;

import by.it.Worker;
import by.it.programmer.Position;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "sysadmin")
public class SysAdmin implements Worker {
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

    public SysAdmin(){
    }
    public SysAdmin(String fio, double salary){
        FIO = fio;
        this.salary = salary;
    }

    public Position getPosition() {
        return position;
    }

    public class Tech{
        public Boolean IsWork = true;

        public Tech(Boolean isWork) {
            IsWork = isWork;
        }
    }

    private final Position position = Position.SYSTEM_ADMINISTRATOR_CASE;

    public void check(){
        System.out.println("Системный администратор проверил производительность системы");
    }

    @Override
    public String toString() {
        return position + ": зарплата - " + getSalary() + " фио - " + getFIO();
    }
    public class InnerAdmin{
        public void upSalary(){
            System.out.println("Зарплата системного администратора повышена");
            setSalary(getSalary()+100);
        }
    }
}
