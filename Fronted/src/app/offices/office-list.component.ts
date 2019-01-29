import { Component, OnInit } from "@angular/core";
import { IOffice } from "../interfaces/office";
import { OfficeService } from "./office.service";

@Component({
    templateUrl: "./office-list.component.html",
    styleUrls: ["./office-list.component.css"]
})

export class OfficeListComponent implements OnInit {
    pageTitle: string = "Office List";

    _listFilter: string;

    get listFilter(): string {
        return this._listFilter;
    }

    set listFilter(value: string) {
        this._listFilter = value;
        this.filteredOffices = this.listFilter ? this.performFilter(this.listFilter) : this.offices;
    }

    filteredOffices: IOffice[] = [];
    offices: IOffice[] = [];

    constructor(private officeService: OfficeService) {
    }

    performFilter(filterBy: string): IOffice[] {
        filterBy = filterBy.toLocaleLowerCase();
        return this.offices.filter((office: IOffice) => 
            office.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }

    onRatingClicked(message: string): void {
        this.pageTitle = "Product List" + message;
    }

    ngOnInit() {
        this.offices = this.officeService.getOffices();
        this.filteredOffices = this.offices;
    }
}
