package by.it.programmer;

public enum Position {
    CEO_CASE("Chief Executive Officer"),
    CTO_CASE("Chief Technology Officer"),
    SYSTEM_ADMINISTRATOR_CASE("System Administrator"),
    DEVELOPMENT_MANAGER("Development Manager"),
    JUNIOR_CASE("Junior"),
    MIDDLE_CASE("Middle"),
    SENIOR_CASE("Senior"),
    LEAD_CASE("Lead");

    public String getPositionName() {
        return positionName;
    }

    private final String positionName;
    Position(String s) {
        positionName = s;
    }
}
