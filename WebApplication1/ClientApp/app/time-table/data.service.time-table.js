var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var DataServiceTimeTable = /** @class */ (function () {
    function DataServiceTimeTable(http) {
        this.http = http;
        this.urlGroup = "api/groups";
        this.urlSpeciality = "api/specialities";
        this.urlFaculty = "api/faculties";
        this.urlTimetable = "api/timtables";
    }
    DataServiceTimeTable.prototype.getSpecialities = function () {
        return this.http.get(this.urlSpeciality);
    };
    DataServiceTimeTable.prototype.getFaculties = function () {
        return this.http.get(this.urlFaculty);
    };
    DataServiceTimeTable.prototype.getGroups = function () {
        return this.http.get(this.urlGroup);
    };
    DataServiceTimeTable.prototype.getTimeTable = function (speciality, faculty, group) {
        return this.http.get(this.urlTimetable + "?speciality=" + speciality + "&faculty=" + faculty + "&group=" + group);
    };
    DataServiceTimeTable = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], DataServiceTimeTable);
    return DataServiceTimeTable;
}());
export { DataServiceTimeTable };
//# sourceMappingURL=data.service.time-table.js.map