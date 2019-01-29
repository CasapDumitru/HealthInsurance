import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OfficeService } from './office.service';
import { IOffice } from '../interfaces/office';

@Component({
  templateUrl: './office-detail.component.html',
  styleUrls: ['./office-detail.component.css']
})
export class OfficeDetailComponent implements OnInit {

  constructor(private route: ActivatedRoute, 
              private officeService: OfficeService,
              private router: Router) { }

  office: IOffice;
  pageTitle: string = "Office Detail";


  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.office = this.officeService.getOffices().find(o => o.id == id);  
  }

  onBack(): void{
    this.router.navigate(['/offices']);
  }

}
