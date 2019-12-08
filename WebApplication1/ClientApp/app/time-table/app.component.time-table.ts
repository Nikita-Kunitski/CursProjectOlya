import { Component, OnInit } from '@angular/core';
import { DataServiceTimeTable } from "./data.service.time-table";
import { Auditorium, Speciality, Faculty } from './time-table';

@Component({
    selector: 'time-table',
    templateUrl: './app.component.time-table.html',
    providers: [DataServiceTimeTable]
})
export class AppComponentTimeTable implements OnInit {

    auditoriums: Auditorium[];
    specialities: Speciality[];
    faculties: Faculty[];

    constructor(private dataService: DataServiceTimeTable) {

    }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        this.dataService.getAuditoriums()
            .subscribe((data: Auditorium[]) => this.auditoriums = data);
        this.dataService.getSpecialities()
            .subscribe((data: Speciality[]) => this.specialities = data);
        this.dataService.getFaculties()
            .subscribe((data: Faculty[]) => this.faculties = data);
    }
    
}