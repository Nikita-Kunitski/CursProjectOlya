import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuditoriumType } from '../time-table/time-table';

@Injectable()
export class DataServiceAuditoriumType {

    private url = "/api/auditoriumType";

    constructor(private http: HttpClient) {
    }

    getAuditoriumTypes() {
        return this.http.get(this.url);
    }

    createAuditoriumType(auditoriumType: AuditoriumType) {
        return this.http.post(this.url, auditoriumType);
    }
    updateAuditoriumType(auditoriumType: AuditoriumType) {

        return this.http.put(this.url + '/' + auditoriumType.id, auditoriumType);
    }
    deleteAuditoriumType(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}