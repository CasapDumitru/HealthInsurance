import { Injectable } from "@angular/core";
import { IOffice } from "../interfaces/office";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class OfficeService {

    constructor(private http: HttpClient){}

    getOffices(): IOffice[] {
        return [
            {
                "id": 1,
                "name": "Office-1",
                "description": "Very Good",
                "starRating": 4.6,
            },
            {
                "id": 2,
                "name": "Office2-Good",
                "description": "Good",
                "starRating": 4.9,
            },
            {
                "id": 3,
                "name": "Office2",
                "description": "Well",
                "starRating": 3.2,
            }
        ]
    }
}