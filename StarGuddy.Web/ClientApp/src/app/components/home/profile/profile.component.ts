import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
//import { BaseService } from "../../../../Services/BaseService";

@Component({
    selector: "home-profile",
    templateUrl: "././profile.component.html",
    styleUrls: ["././profile.component.css"]
})

export class HomeProfileComponent {

    public isLoggedIn: boolean = false;

    //constructor(private readonly bseService: BaseService) { }

    //ngOnInit() {
    //    this.isLoggedIn = this.bseService.IsAuthenticated;
    //}
}
