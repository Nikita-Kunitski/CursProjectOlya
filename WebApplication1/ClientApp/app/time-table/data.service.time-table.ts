import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class DataServiceTimeTable {
    private urlAuditorium = "api/auditorium";
    private urlSpeciality = "api/specialities";
    private urlFaculty = "api/faculties";
    private urlTimetable = "api/timtables";

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

    getTimeTable(speciality: string) {
        return this.http.get(this.urlTimetable + "?speciality="+speciality);
    }

}