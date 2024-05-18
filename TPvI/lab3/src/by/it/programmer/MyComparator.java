package by.it.programmer;

import java.util.Comparator;

public class MyComparator implements Comparator<Middle> {
    @Override
    public int compare(Middle middle1, Middle middle2) {
        if (middle1.salary < middle2.salary) {
            return -1;
        }
        if (middle1.salary > middle2.salary) {
            return 1;
        }
        return 0;
    }
}
