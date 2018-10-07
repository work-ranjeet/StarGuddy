import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataValidator } from "../../../Helper/DataValidator";
import { ToastrService } from "../../../Services/ToastrService";
import { AccountService } from "../Account.Service";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-login",
    templateUrl: "././login.component.html"
})

export class AccountLoginComponent {
    public loginData: ILoginData;
    public accountService: AccountService;
    public router: Router;
    public returnUrl: string;
    public authenticateRoute: ActivatedRoute;
    public showSpinner: boolean = false;
    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService, dataValidator: DataValidator, private toastr: ToastrService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;
        this.dataValidator = dataValidator;

        this.loginData = {} as ILoginData;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/profile";
    }

    login() {
        this.showSpinner = true;
        if (this.dataValidator.IsValidObject(this.loginData)) {
            this.accountService.login(this.loginData).subscribe(
                data => {                    
                    //if (data.isEmailVerified)
                    //    this.router.navigate([this.returnUrl]);
                    //else {
                    //    this.router.navigate(['acc-cnf-email-sent']);
                    //}
                    this.showSpinner = false;
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.showSpinner = false;
                    this.toastr.error(error.error);
                });
        }
    }
}
