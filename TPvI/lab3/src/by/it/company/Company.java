package by.it.company;
import by.it.head.*;
import by.it.administration.*;
import by.it.manager.*;
import by.it.programmer.*;

import javax.xml.bind.annotation.XmlRootElement;
import java.util.ArrayList;

public class Company {
    public ArrayList<Object> workers;

    public Company(){}

    public Company(ArrayList<Object> workers){
        this.workers = workers;
    }

    @Override
    public String toString() {
        return "Company{" +
                "workers=" + workers +
                '}';
    }
}
