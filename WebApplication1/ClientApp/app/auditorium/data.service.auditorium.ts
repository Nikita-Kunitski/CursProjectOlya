import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Auditorium } from './auditorium';

@Injectable()
export class DataServiceAuditorium {

    private url = "/api/auditorium";

    constructor(private http: HttpClient) {
    }

    getAuditoriums() {
        return this.http.get(this.url);
    }

    createAuditorium(auditorium: Auditorium) {
        return this.http.post(this.url, auditorium);
    }
    updateAuditorium(auditorium: Auditorium) {

        return this.http.put(this.url + '/' + auditorium.id, auditorium);
    }
    deleteAuditorium(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}