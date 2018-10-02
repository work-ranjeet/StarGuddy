import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";

import { LogInOutComponent } from "./logInOut/logInOut.component";

@NgModule({
    declarations: [
        FooterComponent, NavMenuComponent, LogInOutComponent
    ],
    imports: [RouterModule, FormsModule, CommonModule],
    exports: [FooterComponent, NavMenuComponent, LogInOutComponent]
})

export class CommonModuleShared {
}
