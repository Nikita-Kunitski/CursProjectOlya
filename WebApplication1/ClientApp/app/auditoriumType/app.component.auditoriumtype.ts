import { Component, OnInit } from '@angular/core';
import { DataService } from "./data.service.auditoriumtype";
import { AuditoriumType } from './auditoriumtype';

@Component({
    selector: 'app',
    templateUrl: './app.component.auditoriumtype.html',
    providers: [DataService]
})
export class AppComponentAuditoriumType implements OnInit {

    auditoriumType: AuditoriumType = new AuditoriumType();   // изменяемый товар
    auditoriumTypes: AuditoriumType[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadAuditoriumTypes();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadAuditoriumTypes() {
        this.dataService.getAuditoriumTypes()
            .subscribe((data: AuditoriumType[]) => this.auditoriumTypes = data);
    }
    // сохранение данных
    save() {
        if (this.auditoriumType.id == null) {
            this.dataService.createAuditoriumType(this.auditoriumType)
                .subscribe((data: AuditoriumType) => this.auditoriumTypes.push(data));
        } else {
            this.dataService.updateAuditoriumType(this.auditoriumType)
                .subscribe(data => this.loadAuditoriumTypes());
        }
        this.cancel();
    }
    editAuditoriumType(a: AuditoriumType) {
        this.auditoriumType = a;
    }
    cancel() {
        this.auditoriumType = new AuditoriumType();
        this.tableMode = true;
    }
    delete(a: AuditoriumType) {
        this.dataService.deleteAuditoriumType(a.id)
            .subscribe(data => this.loadAuditoriumTypes());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}