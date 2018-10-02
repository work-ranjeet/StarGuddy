import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-management-add-phone-number",
    templateUrl: "././addPhoneNumber.component.html",
    styleUrls: ['././addPhoneNumber.component.css']
})

export class AddPhoneNumberComponent {
    
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;
    loginData: ILoginData = {} as ILoginData;
    profileSettingsService: ProfileSettingsService;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, profileSettingsService: ProfileSettingsService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.profileSettingsService = profileSettingsService;
        this.dataValidator = dataValidator;
        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }

    //login() {
    //    if (this.dataValidator.IsValidObject(this.loginData)) {
    //        this.accountService.login(this.loginData).subscribe(
    //            result => {
    //                this.router.navigate([this.returnUrl]);
    //            },
    //            error => {
    //                console.error(error);
    //            });
    //    }
    //}
}
