import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class DataServiceTimeTable {
    private urlGroup = "api/groups";
    private urlSpeciality = "api/specialities";
    private urlFaculty = "api/faculties";
    private urlTimetable = "api/timtables";

    constructor(private http: HttpClient) {
    }

    getSpecialities() {
        return this.http.get(this.urlSpeciality);
    }

    getFaculties() {
        return this.http.get(this.urlFaculty);
    }

    getGroups() {
        return this.http.get(this.urlGroup);
    }

    getTimeTable(speciality: string, faculty: string, group: string) {
        return this.http.get(this.urlTimetable + "?speciality=" + speciality + "&faculty=" + faculty + "&group=" + group);
    }

}