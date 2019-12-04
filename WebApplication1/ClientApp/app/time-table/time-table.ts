export class Auditorium {
    constructor(
       public id?: number,
       public auditoriumNumber?: string,
       public auditoriumCapacity?: number,
       public auditoriumType?: AuditoriumType) { }
}

export class AuditoriumType {
    constructor(
       public id?: number,
       public auditoriumAbbreviation?: string,
       public auditoriumName?: string) { }
}

export class Subject {
    constructor(
        public id?: number,
        public subjectAbbreviation?: string,
        public subjectName?: string) {
    }
}

export class Pulpit {
    constructor(
        public id?: number,
        public pulpitAbbreviation?: string,
        public pulpitName?: string //может быть проблема в получении без коллекции
    ) {
    }
}

export class Teacher {
    constructor(
        public id?: number,
        public fullName?: string,
        public pulpit?:Pulpit
        ) { }
}

export class LessonNumber {
    constructor(
        public id?: number,
        public number?: number,
        public begin?: Date,
        public end?: Date) {
    }
}

export class Faculty {
    constructor(
        public id?: number,
        public facultyAbbreviation?: string,
        public facultyName?:string) {
    }
}
//export class Group {
//    constructor(
//        public id?: number,
//        public code?: string,
//        public 
//    ) {
//    }
//}

export enum DayOfWeek {
    Понедельник,
    Вторник,
    Среда,
    Четверг,
    Пятница,
    Суббота
}