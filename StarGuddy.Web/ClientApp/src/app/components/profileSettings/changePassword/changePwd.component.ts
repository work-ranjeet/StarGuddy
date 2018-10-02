import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import IChangePassword = App.Client.Account.IChangePassword;

@Component({
    selector: "account-management-change-password",
    templateUrl: "././changePwd.component.html",
    styleUrls: ['././changePwd.component.css']
})

export class ChangePwdComponent {
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;
    changePwd: IChangePassword = {} as IChangePassword;
    manageAccountService: ProfileSettingsService;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, manageAccountService: ProfileSettingsService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.manageAccountService = manageAccountService;
        this.dataValidator = dataValidator;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }

    ngOnInit() {
        this.changePwd = {} as IChangePassword;

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
