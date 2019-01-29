import { NgModule } from "@angular/core";
import { OfficeDetailComponent } from "./office-detail.component";
import { OfficeListComponent } from "./office-list.component";
import { ConvertToSpacesPipe } from "../shared/convert-to-spaces.pipe";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { OfficeRoutingModule } from "./office-routing.module";

@NgModule({
    declarations: [
        OfficeDetailComponent,
        OfficeListComponent,
        ConvertToSpacesPipe,
    ],
    imports: [
        SharedModule,
        OfficeRoutingModule
    ]
})

export class OfficeModule {}