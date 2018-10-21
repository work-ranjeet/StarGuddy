import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../Account.Service";
import { ToastrService } from "../../../Services/ToastrService";
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';

@Component({
    selector: "account-confirm-email",
    templateUrl: "././confirmEmail.html"
})

export class AccountConfirmEmailComponent {
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
            result => {
                this.toastr.info(result);
            });
    }
}
