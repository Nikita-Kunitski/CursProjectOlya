import { Component, OnInit } from '@angular/core';
import { DataServiceTimeTable } from "./data.service.time-table";
import { Auditorium, Speciality } from './time-table';

@Component({
    selector: 'time-table',
    templateUrl: './app.component.time-table.html',
    providers: [DataServiceTimeTable]
})
export class AppComponentTimeTable implements OnInit {

    auditoriums: Auditorium[];
    specialities: Speciality[];

    constructor(private dataService: DataServiceTimeTable) {

    }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        //this.dataService.getAuditoriums()
        //    .subscribe((data: Auditorium[]) => this.auditoriums = data);
        this.dataService.getSpecialities()
            .subscribe((data: Speciality[]) => this.specialities = data);
    }
    
}