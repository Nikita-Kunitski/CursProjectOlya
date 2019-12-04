import { Component, OnInit } from '@angular/core';
import { DataServiceTimeTable } from "./data.service.time-table";
import { AuditoriumType, Auditorium } from '../time-table/time-table';

@Component({
    selector: 'auditorium',
    templateUrl: './app.component.time-table.html',
    providers: [DataServiceTimeTable]
})
export class AppComponentTimeTable implements OnInit {

    constructor(private dataService: DataServiceTimeTable) { }
    auditorium: Auditorium = new Auditorium();
    auditoriums: Auditorium[];


    ngOnInit() {
        this.loadAuditoriums();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadAuditoriums() {
        this.dataService.getAuditoriums()
            .subscribe((data: Auditorium[]) => this.auditoriums = data);
    }
    
}