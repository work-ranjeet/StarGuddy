import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
//import { MatMenuModule } from "@angular/material";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";

import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";

import { LogInOutComponent } from "./logInOut/logInOut.component";

@NgModule({
    declarations: [
        FooterComponent, NavMenuComponent, LogInOutComponent, HeadingComponent, PageHeadingComponent
    ],
    imports: [RouterModule, FormsModule, CommonModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    exports: [FooterComponent, NavMenuComponent, LogInOutComponent, HeadingComponent, PageHeadingComponent]
})

export class CommonModuleShared {
}
