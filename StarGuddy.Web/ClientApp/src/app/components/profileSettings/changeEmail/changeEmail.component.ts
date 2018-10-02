import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;

@Component({
    selector: "account-management-change-email",
    templateUrl: "././changeEmail.component.html",
    styleUrls: ['././changeEmail.component.css']
})

export class ChangeEmailComponent {

    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;
    userEmail: IUserEmail = {} as IUserEmail;
    profileSettingService: ProfileSettingsService;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, profileSettingService: ProfileSettingsService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.profileSettingService = profileSettingService;
        this.dataValidator = dataValidator;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }


    updateEmail() {
        if (this.dataValidator.IsValidObject(this.userEmail)) {
            this.profileSettingService.updateEmail(this.userEmail).subscribe(
                result => {

                },
                error => {
                    console.error(error);
                });
        }
    }
}
