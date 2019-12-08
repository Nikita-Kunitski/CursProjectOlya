import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataServiceTimeTable {
    private urlAuditorium = "api/auditorium";
    private urlSpeciality = "api/specialities";
    private urlFaculty = "api/faculties";

    constructor(private http: HttpClient) {
    }

    getAuditoriums() {
        return this.http.get(this.urlAuditorium);
    }

    getSpecialities() {
        return this.http.get(this.urlSpeciality);
    }

    getFaculties() {
        return this.http.get(this.urlFaculty);
    }
}