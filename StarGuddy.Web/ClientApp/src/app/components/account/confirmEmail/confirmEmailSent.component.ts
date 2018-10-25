import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "../../../Services/ToastrService";
import { AccountService } from "../Account.Service";

@Component({
    selector: "account-confirm-email-sent",
    templateUrl: "././confirmEmailSent.html"
})

export class AccountConfirmEmailSentComponent {
    router: Router;
    authenticateRoute: ActivatedRoute;

    public id: string = "";
    public name: string = "";
    public sender: string = "";
    public message: string = "";
    public isMailSending: boolean = false;

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
            this.sender = param['sender'];
        });

        //if (this.sender != undefined && this.sender == "signup") {
        //    this.sendMail();
        //}
    }


    sendMail() {
        this.isMailSending = true;
        this.accountService.resendEmailActivationCode(this.id).subscribe(
            (data: any) => {
                var message = data.message;
                if (message != undefined && message != null) {
                    console.info(message.toString());
                }

                this.isMailSending = false;
            },
            error => {
                this.isMailSending = false;
                this.toastr.error(error.message == undefined ? "Oops! try again." : error.message);
            });
    }
}
