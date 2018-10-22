import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "../../../Services/ToastrService";
import { AccountService } from "../Account.Service";
import { HttpResponse } from "@angular/common/http";

@Component({
    selector: "account-confirm-email-sent",
    templateUrl: "././confirmEmailSent.html"
})

export class AccountConfirmEmailSentComponent {
    router: Router;
    authenticateRoute: ActivatedRoute;

    public id: string = "";
    public name: string = "";

    constructor(router: Router, authRoute: ActivatedRoute,
        private readonly accountService: AccountService,
        private readonly toastr: ToastrService) {
        this.router = router;
        this.authenticateRoute = authRoute;

    }

    ngOnInit() {
        this.authenticateRoute.params.subscribe(param => {
            this.name = param['firstName'];
            this.id = param['id'];
        });
    }

    resend() {
        this.accountService.resendEmailActivationCode(this.id).subscribe(
            (data: Response) => {
                var message = data.body;
                if (message != null) {
                    this.toastr.info(message.toString());
                }
            },
            error => {
                this.toastr.error(error.message == undefined ? "Oops! try again." : error.message);
            });
    }
}
