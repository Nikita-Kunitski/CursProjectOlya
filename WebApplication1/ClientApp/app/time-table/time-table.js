var Auditorium = /** @class */ (function () {
    function Auditorium(id, auditoriumNumber, auditoriumCapacity, auditoriumType) {
        this.id = id;
        this.auditoriumNumber = auditoriumNumber;
        this.auditoriumCapacity = auditoriumCapacity;
        this.auditoriumType = auditoriumType;
    }
    return Auditorium;
}());
export { Auditorium };
var AuditoriumType = /** @class */ (function () {
    function AuditoriumType(id, auditoriumAbbreviation, auditoriumName) {
        this.id = id;
        this.auditoriumAbbreviation = auditoriumAbbreviation;
        this.auditoriumName = auditoriumName;
    }
    return AuditoriumType;
}());
export { AuditoriumType };
var Subject = /** @class */ (function () {
    function Subject(id, subjectAbbreviation, subjectName) {
        this.id = id;
        this.subjectAbbreviation = subjectAbbreviation;
        this.subjectName = subjectName;
    }
    return Subject;
}());
export { Subject };
var Pulpit = /** @class */ (function () {
    function Pulpit(id, pulpitAbbreviation, pulpitName //может быть проблема в получении без коллекции
    ) {
        this.id = id;
        this.pulpitAbbreviation = pulpitAbbreviation;
        this.pulpitName = pulpitName;
    }
    return Pulpit;
}());
export { Pulpit };
var Teacher = /** @class */ (function () {
    function Teacher(id, fullName, pulpit) {
        this.id = id;
        this.fullName = fullName;
        this.pulpit = pulpit;
    }
    return Teacher;
}());
export { Teacher };
var LessonNumber = /** @class */ (function () {
    function LessonNumber(id, number, begin, end) {
        this.id = id;
        this.number = number;
        this.begin = begin;
        this.end = end;
    }
    return LessonNumber;
}());
export { LessonNumber };
var Faculty = /** @class */ (function () {
    function Faculty(id, facultyAbbreviation, facultyName) {
        this.id = id;
        this.facultyAbbreviation = facultyAbbreviation;
        this.facultyName = facultyName;
    }
    return Faculty;
}());
export { Faculty };
//export class Group {
//    constructor(
//        public id?: number,
//        public code?: string,
//        public 
//    ) {
//    }
//}
export var DayOfWeek;
(function (DayOfWeek) {
    DayOfWeek[DayOfWeek["\u041F\u043E\u043D\u0435\u0434\u0435\u043B\u044C\u043D\u0438\u043A"] = 0] = "\u041F\u043E\u043D\u0435\u0434\u0435\u043B\u044C\u043D\u0438\u043A";
    DayOfWeek[DayOfWeek["\u0412\u0442\u043E\u0440\u043D\u0438\u043A"] = 1] = "\u0412\u0442\u043E\u0440\u043D\u0438\u043A";
    DayOfWeek[DayOfWeek["\u0421\u0440\u0435\u0434\u0430"] = 2] = "\u0421\u0440\u0435\u0434\u0430";
    DayOfWeek[DayOfWeek["\u0427\u0435\u0442\u0432\u0435\u0440\u0433"] = 3] = "\u0427\u0435\u0442\u0432\u0435\u0440\u0433";
    DayOfWeek[DayOfWeek["\u041F\u044F\u0442\u043D\u0438\u0446\u0430"] = 4] = "\u041F\u044F\u0442\u043D\u0438\u0446\u0430";
    DayOfWeek[DayOfWeek["\u0421\u0443\u0431\u0431\u043E\u0442\u0430"] = 5] = "\u0421\u0443\u0431\u0431\u043E\u0442\u0430";
})(DayOfWeek || (DayOfWeek = {}));
//# sourceMappingURL=time-table.js.map