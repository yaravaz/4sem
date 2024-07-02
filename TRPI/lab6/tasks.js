// task 1
var array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
var car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
var car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
var car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
var arrayCars = [{
        cars: [car1, car2]
    }];
var Group = {
    students: [
        {
            id: 1,
            name: 'Vasya',
            group: 10,
            marks: [
                { subject: "ОАиП", mark: 3, done: true },
                { subject: "ОКГ", mark: 8, done: true }
            ]
        },
        {
            id: 2,
            name: 'Ivan',
            group: 11,
            marks: [
                { subject: "БД", mark: 3, done: true },
                { subject: "ТРПИ", mark: 4, done: true }
            ]
        },
        {
            id: 3,
            name: 'Masha',
            group: 11,
            marks: [
                { subject: "АЛОЦВ", mark: 9, done: true }
            ]
        }
    ],
    mark: 3,
    group: 7,
    studentsFilter: function (group) {
        return this.students.filter(function (student) { return student.group == group; });
    },
    marksFilter: function (mark) {
        return this.students.filter(function (student) { return student.marks.some(function (m) { return m.mark == mark; }); });
    },
    deleteStudent: function (id) {
        this.students = this.students.filter(function (student) { return student.id !== id; });
    }
};
console.log(Group.studentsFilter(11));
console.log(Group.marksFilter(3));
Group.deleteStudent(2);
console.log(Group.students);
