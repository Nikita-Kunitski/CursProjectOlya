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
import { DataServiceAuditoriumType } from "./data.service.auditoriumtype";
import { AuditoriumType } from './auditoriumtype';
var AppComponentAuditoriumType = /** @class */ (function () {
    function AppComponentAuditoriumType(dataService) {
        this.dataService = dataService;
        this.auditoriumType = new AuditoriumType(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    AppComponentAuditoriumType.prototype.ngOnInit = function () {
        this.loadAuditoriumTypes(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    AppComponentAuditoriumType.prototype.loadAuditoriumTypes = function () {
        var _this = this;
        this.dataService.getAuditoriumTypes()
            .subscribe(function (data) { return _this.auditoriumTypes = data; });
    };
    // сохранение данных
    AppComponentAuditoriumType.prototype.save = function () {
        var _this = this;
        if (this.auditoriumType.id == null) {
            this.dataService.createAuditoriumType(this.auditoriumType)
                .subscribe(function (data) { return _this.auditoriumTypes.push(data); });
        }
        else {
            this.dataService.updateAuditoriumType(this.auditoriumType)
                .subscribe(function (data) { return _this.loadAuditoriumTypes(); });
        }
        this.cancel();
    };
    AppComponentAuditoriumType.prototype.editAuditoriumType = function (a) {
        this.auditoriumType = a;
    };
    AppComponentAuditoriumType.prototype.cancel = function () {
        this.auditoriumType = new AuditoriumType();
        this.tableMode = true;
    };
    AppComponentAuditoriumType.prototype.delete = function (a) {
        var _this = this;
        this.dataService.deleteAuditoriumType(a.id)
            .subscribe(function (data) { return _this.loadAuditoriumTypes(); });
    };
    AppComponentAuditoriumType.prototype.add = function () {
        this.cancel();
        this.tableMode = false;
    };
    AppComponentAuditoriumType = __decorate([
        Component({
            selector: 'app1',
            templateUrl: './app.component.auditoriumtype.html',
            providers: [DataServiceAuditoriumType]
        }),
        __metadata("design:paramtypes", [DataServiceAuditoriumType])
    ], AppComponentAuditoriumType);
    return AppComponentAuditoriumType;
}());
export { AppComponentAuditoriumType };
//# sourceMappingURL=app.component.auditoriumtype.js.map