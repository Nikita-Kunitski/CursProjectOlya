import { Component, OnInit } from '@angular/core';
import { DataServiceTimeTable } from "./data.service.time-table";
import { Speciality, Faculty, TimeTable, Group } from './time-table';

@Component({
    selector: 'time-table',
    templateUrl: './app.component.time-table.html',
    providers: [DataServiceTimeTable]
})
export class AppComponentTimeTable implements OnInit {

    specialities: Speciality[];
    faculties: Faculty[];
    timetables: TimeTable[];
    groups: Group[];

    constructor(private dataService: DataServiceTimeTable) {
    }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        this.dataService.getSpecialities()
            .subscribe((data: Speciality[]) => this.specialities = data);
        this.dataService.getFaculties()
            .subscribe((data: Faculty[]) => this.faculties = data);
        this.dataService.getGroups()
            .subscribe((data: Group[]) => this.groups = data);
    }

    setFilter(speciality: string, faculty: string, group: string) {
        this.dataService.getTimeTable(speciality, faculty,group)
            .subscribe((data: TimeTable[]) => this.timetables = data);
    }
}