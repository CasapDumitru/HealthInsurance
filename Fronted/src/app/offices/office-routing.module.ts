import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { OfficeListComponent } from "./office-list.component";
import { OfifceDetailGuard } from "./ofifce-detail.guard";
import { OfficeDetailComponent } from "./office-detail.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'offices', component: OfficeListComponent},
            { path: 'offices/:id',
              canActivate: [OfifceDetailGuard],
              component: OfficeDetailComponent}
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class OfficeRoutingModule{}