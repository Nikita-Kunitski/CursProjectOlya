import { Component, OnInit } from '@angular/core';
import { DataServiceAuditorium} from "./data.service.auditorium";
import { Auditorium } from './auditorium';

@Component({
    selector: 'app',
    templateUrl: './app.component.auditorium.html',
    providers: [DataServiceAuditorium]
})
export class AppComponentAuditorium implements OnInit {
    auditorium: Auditorium = new Auditorium();   // изменяемый товар
    auditoriums: Auditorium[];                // массив товаров
    tableMode: boolean = true; 

    constructor(private dataService: DataServiceAuditorium) { }

    ngOnInit() {
        this.loadAuditoriums();    // загрузка данных при старте компонента  
    }

    loadAuditoriums() {
        this.dataService.getAuditoriums()
            .subscribe((data: Auditorium[]) => this.auditoriums = data);
    }

    save() {
        if (this.auditorium.id == null) {
            this.dataService.createAuditorium(this.auditorium)
                .subscribe((data: Auditorium) => this.auditoriums.push(data));
        } else {
            this.dataService.updateAuditorium(this.auditorium)
                .subscribe(data => this.loadAuditoriums());
        }
        this.cancel();
    }

    editAuditorium(a: Auditorium) {
        this.auditorium = a;
    }

    cancel() {
        this.auditorium = new Auditorium();
        this.tableMode = true;
    }

    delete(a: Auditorium) {
        this.dataService.deleteAuditorium(a.id)
            .subscribe(data => this.loadAuditoriums());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}