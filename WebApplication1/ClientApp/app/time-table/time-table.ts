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

export enum DayOfWeek {
    Понедельник,
    Вторник,
    Среда,
    Четверг,
    Пятница,
    Суббота
}

export class Faculty {
    constructor(
        public id?: number,
        public facultyAbbreviation?: string,
        public facultyName?: string) {
    }
}

export class Group {
    constructor(
        public id?: number,
        public code?: string,
        public countStudent?: number,
        public faculty?: Faculty,
        public speciality?: Speciality
    ) {
    }
}

export class LessonNumber {
    constructor(
        public id?: number,
        public number?: number,
        public begin?: Date,
        public end?: Date) {
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

export class Speciality {
    constructor(
        public id?: number,
        public code?: string,
        public specialityAbbreviation?: string,
        public specialityName?: string,
        public faculty?: Faculty) {
    }
}

export class Subject {
    constructor(
        public id?: number,
        public subjectAbbreviation?: string,
        public subjectName?: string) {
    }
}

export class Teacher {
    constructor(
        public id?: number,
        public fullName?: string,
        public pulpit?:Pulpit
        ) { }
}

export class TimeTable {
    constructor(
        public id?: number,
        public dayOfWeek?: DayOfWeek,
        public typeLesson?: TypeLesson,
        public numbersubjectofday?: LessonNumber,
        public subject?: Subject,
        public teacher?: Teacher,
        public auditorium?: Auditorium,
        public group?: Group,
        public specialities?: Speciality) {

    }
}

export enum TypeLesson {
    Лекция,
    Практика,
    Лаб
}
