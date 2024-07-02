// task 1

interface IArrayElem{
    id: number;
    name: string;
    group: number;
}

const array: IArrayElem[] = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

// taks 2

type CarsType = {
    manufacturer?: string;
    model?: string;
}

let car: CarsType = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';

// task 3 

type ArrayCarsType = {
    cars: CarsType[]
}

const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

// task 4 

type MarkFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;

type GroupFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12;

type DoneType = boolean;

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}

type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}

type GroupType = {
    students: StudentType[] // массив студентов типа StudentType
    studentsFilter: (group: number) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: number) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    mark: MarkFilterType,
    group: GroupFilterType,
}

let Group: GroupType = {
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

    studentsFilter: function(group: number): StudentType[] {
        return this.students.filter(student => student.group == group);
    },

    marksFilter: function(mark: number): StudentType[] {
        return this.students.filter(student => student.marks.some(m => m.mark == mark));
    },

    deleteStudent: function(id: number): void {
        this.students = this.students.filter(student => student.id !== id);
    }
};

console.log(Group.studentsFilter(11));
console.log(Group.marksFilter(3));
Group.deleteStudent(2);
console.log(Group.students);