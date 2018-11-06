import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../Account.Service";
import { ToastrService } from "../../../Services/ToastrService";

@Component({
    selector: "account-confirm-email",
    templateUrl: "././confirmEmail.html"
})

export class AccountConfirmEmailComponent {
    public isEmailVerified: boolean = false;
    public verificationCode: string = "";

    constructor(

        private readonly router: Router,
        private readonly authRoute: ActivatedRoute,
        private readonly toastr: ToastrService,
        private readonly accountService: AccountService) {
        this.authRoute.params.subscribe(param => this.verificationCode = param['code']);
    }

    ngOnInit() {
        this.activate();
    }

    activate() {
        this.accountService.activateEmail(this.verificationCode).subscribe(
            (data: Response) => {
                this.isEmailVerified = true;
                var message = data.body;
                if (message != null) {
                    this.toastr.success(message.toString());
                }
            },
            (error) => {
                this.toastr.error(error.message == undefined ? "Oops! try again." : error.message);
            });
    }
}
