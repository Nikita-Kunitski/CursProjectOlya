var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DataServiceTimeTable } from "./data.service.time-table";
import { Auditorium } from '../time-table/time-table';
var AppComponentTimeTable = /** @class */ (function () {
    function AppComponentTimeTable(dataService) {
        this.dataService = dataService;
        this.auditorium = new Auditorium();
    }
    AppComponentTimeTable.prototype.ngOnInit = function () {
        this.loadAuditoriums(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    AppComponentTimeTable.prototype.loadAuditoriums = function () {
        var _this = this;
        this.dataService.getAuditoriums()
            .subscribe(function (data) { return _this.auditoriums = data; });
    };
    AppComponentTimeTable = __decorate([
        Component({
            selector: 'auditorium',
            templateUrl: './app.component.time-table.html',
            providers: [DataServiceTimeTable]
        }),
        __metadata("design:paramtypes", [DataServiceTimeTable])
    ], AppComponentTimeTable);
    return AppComponentTimeTable;
}());
export { AppComponentTimeTable };
//# sourceMappingURL=app.component.time-table.js.map