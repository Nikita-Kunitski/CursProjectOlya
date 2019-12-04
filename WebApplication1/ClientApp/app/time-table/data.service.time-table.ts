import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuditoriumType } from '../time-table/time-table';

@Injectable()
export class DataServiceTimeTable {

    private urlAuditoriumType = "/api/auditoriumType";
    private urlAuditorium = "/api/auditorium";

    constructor(private http: HttpClient) {
    }

    getAuditoriumTypes() {
        return this.http.get(this.urlAuditoriumType);
    }

    getAuditoriums() {
        return this.http.get(this.urlAuditorium);
    }
}