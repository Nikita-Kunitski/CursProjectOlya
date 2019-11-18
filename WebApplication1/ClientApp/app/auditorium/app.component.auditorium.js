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
import { DataServiceAuditorium } from "./data.service.auditorium";
import { Auditorium } from './auditorium';
var AppComponentAuditorium = /** @class */ (function () {
    function AppComponentAuditorium(dataService) {
        this.dataService = dataService;
        this.auditorium = new Auditorium(); // изменяемый товар
        this.tableMode = true;
    }
    AppComponentAuditorium.prototype.ngOnInit = function () {
        this.loadAuditoriums(); // загрузка данных при старте компонента  
    };
    AppComponentAuditorium.prototype.loadAuditoriums = function () {
        var _this = this;
        this.dataService.getAuditoriums()
            .subscribe(function (data) { return _this.auditoriums = data; });
    };
    AppComponentAuditorium.prototype.save = function () {
        var _this = this;
        if (this.auditorium.id == null) {
            this.dataService.createAuditorium(this.auditorium)
                .subscribe(function (data) { return _this.auditoriums.push(data); });
        }
        else {
            this.dataService.updateAuditorium(this.auditorium)
                .subscribe(function (data) { return _this.loadAuditoriums(); });
        }
        this.cancel();
    };
    AppComponentAuditorium.prototype.editAuditorium = function (a) {
        this.auditorium = a;
    };
    AppComponentAuditorium.prototype.cancel = function () {
        this.auditorium = new Auditorium();
        this.tableMode = true;
    };
    AppComponentAuditorium.prototype.delete = function (a) {
        var _this = this;
        this.dataService.deleteAuditorium(a.id)
            .subscribe(function (data) { return _this.loadAuditoriums(); });
    };
    AppComponentAuditorium.prototype.add = function () {
        this.cancel();
        this.tableMode = false;
    };
    AppComponentAuditorium = __decorate([
        Component({
            selector: 'app',
            templateUrl: './app.component.auditorium.html',
            providers: [DataServiceAuditorium]
        }),
        __metadata("design:paramtypes", [DataServiceAuditorium])
    ], AppComponentAuditorium);
    return AppComponentAuditorium;
}());
export { AppComponentAuditorium };
//# sourceMappingURL=app.component.auditorium.js.map