package by.it.main;

import by.it.Progers;
import by.it.ProgersHandler;
import by.it.Validation;
import by.it.head.*;
import by.it.administration.*;
import by.it.manager.*;
import by.it.programmer.*;
import by.it.company.*;
import org.apache.log4j.Level;
import org.apache.log4j.Logger;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;
import com.google.gson.Gson;

import javax.xml.bind.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) throws IOException {
        Ceo ceo = new Ceo("ceo1", 444.3);
        Cto cto1 = new Cto("tech dir1", 333.33);
        SysAdmin sysAdmin1 = new SysAdmin("sysadmin1", 50.33);
        SysAdmin sysAdmin2 = new SysAdmin("sysadmin2", 200.55);
        DevelopManager developManager1 = new DevelopManager("devel_manager1", 100.33);
        DevelopManager developManager2 = new DevelopManager("devel_manager2", 200.99);
        Lead lead1 = new Lead("lead1", 222.19);
        Senior senior1 = new Senior("senior1", 199.19);
        Senior senior2 = new Senior("senior2", 211.42);
        Middle middle1 = new Middle("middle1", 100.99);
        Middle middle2 = new Middle("middle2", 150.99);
        Middle middle3 = new Middle("middle3", 121.12);
        Junior junior1 = new Junior("jun1", 99.19);
        Junior junior2 = new Junior("jun2", 50.19);

        ArrayList<Object> workers = new ArrayList<>();
        //workers.add(cto1);
        workers.add(sysAdmin1);
        workers.add(sysAdmin2);
        workers.add(developManager1);
        workers.add(developManager2);
        workers.add(lead1);
        workers.add(senior1);
        workers.add(senior2);
        workers.add(middle1);
        workers.add(middle2);
        workers.add(middle3);
        workers.add(junior1);
        workers.add(junior2);

        Company company = new Company(workers);

        ceo.analysis();
        System.out.println(ceo.countWorkers(company));

        Company sorted = ceo.sortBySalary(company);
        for (Object worker : sorted.workers) {
            System.out.println(worker);
        }

        System.out.println();

        ceo.findWorker(company, Position.CTO_CASE);

        Validation validator = new Validation();
        validator.Valid();

        try {
            XMLReader reader = XMLReaderFactory.createXMLReader();
            ProgersHandler handler = new ProgersHandler();
            reader.setContentHandler(handler);
            reader.parse("files.xml.xml");
        } catch (IOException e) {
            System.out.println(e.getMessage());
        } catch (SAXException e) {
            System.out.println(e.getMessage());
        }

        Gson gson = new Gson();
        String jsonStr = gson.toJson(company);

        System.out.println(jsonStr);
        FileOutputStream fileOutputStream = new FileOutputStream(new File("files/file.json"));
        fileOutputStream.write(jsonStr.getBytes());
        fileOutputStream.close();

        String string = "";
        FileInputStream fileInputStream = new FileInputStream(new File("files/file.json"));
        int i;
        while ((i = fileInputStream.read()) != -1) {
            string += (char) i;
        }
        fileInputStream.close();
        Company comp = gson.fromJson(string, Company.class);
        System.out.println(comp.toString());

        Middle[] middles = new Middle[]{
                middle1, middle2, middle3
        };
        MyComparator comparator = new MyComparator();

        Arrays.sort(middles, comparator);
        for (var item: middles) {
            System.out.println(item);
        }

        Middle middle4 = new Middle("enjb ebjn ejbn", 12.45);
        Middle middle5 = new Middle("vfldkjg5", 1266.02);
        Middle middle6 = new Middle("dfomMbk fb", 400.95);
        Middle middle7 = new Middle("kbn bkb s", 499.52);

        ArrayList<Middle> middleList = new ArrayList<>();
        middleList.add(middle1);
        middleList.add(middle2);
        middleList.add(middle3);
        middleList.add(middle4);
        middleList.add(middle5);
        middleList.add(middle6);
        middleList.add(middle7);

        var middleList1 = middleList.stream()
                .filter(middle -> middle.salary > 200)
                .collect(Collectors.toList());

        var middleList2 = middleList.stream()
                .sorted(Comparator.comparing(Middle::getSalary))
                .collect(Collectors.toList());

        var middleList3 = middleList.stream()
                .map(Middle::getFIO)
                .collect(Collectors.toList());

        var middleList4 = middleList.stream()
                .limit(3)
                .collect(Collectors.toList());

        boolean anyMatch = middleList.stream()
                .anyMatch(middle -> middle.getSalary() > 600);

        boolean allMatch = middleList.stream()
                .allMatch(middle -> middle.getSalary() > 300);


        System.out.println();
        for (var item: middleList1) {
            System.out.println(item);
        }

        System.out.println();
        for (var item: middleList2) {
            System.out.println(item);
        }

        System.out.println();
        for (var item: middleList3) {
            System.out.println(item);
        }

        System.out.println();
        for (var item: middleList4) {
            System.out.println(item);
        }

        System.out.println();
        System.out.println(anyMatch);

        System.out.println();
        System.out.println(allMatch);


    }
}
