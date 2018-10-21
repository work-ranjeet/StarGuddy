import { Component, Input } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { AccountService } from "../Account.Service";
import { Toast } from "ng5-toastr";
import { ToastrService } from "../../../Services/ToastrService";

@Component({
    selector: "account-confirm-email-sent",
    templateUrl: "././confirmEmailSent.html"
})

export class AccountConfirmEmailSentComponent {
    router: Router;
    authenticateRoute: ActivatedRoute;

    public name: string = "";

    @Input() public message: string | undefined;


    constructor(router: Router, authRoute: ActivatedRoute,
        private readonly accountService: AccountService,
        private readonly toastr: ToastrService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.authenticateRoute.params.subscribe(param => this.name = param['firstName']);
    }

    loadData() {

    }


    resend() {
        this.accountService.resendEmailActivationCode().subscribe(
            data => {
                this.toastr.info(data);
            },
            error => {
                this.toastr.error(error.message == undefined ? "Oops! try again." : error.message);
            });
    }
}
