import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { DataValidator } from "../../../../Helper/DataValidator";
import { ToastrService } from "../../../../Services/ToastrService";
import { AccountService } from "../../Account.Service";
import IApplicationUser = App.Client.Account.IApplicationUser;

@Component({
    selector: 'signup-jobProvider',
    templateUrl: './././jobProvider.component.html',
    styleUrls: ['./././jobProvider.component.css']
})
export class SignUpJobProviderComponent {
    private readonly accountService: AccountService;
    private readonly dataValidator: DataValidator
    router: Router;
    applicationUser: IApplicationUser;

    constructor(router: Router, accountService: AccountService, dataValidator: DataValidator, private toastr: ToastrService) {
        this.router = router;
        this.accountService = accountService;
        this.dataValidator = dataValidator;
        this.applicationUser = { Gender: 'M', IsCastingProfessional: true } as IApplicationUser;
    }
   
    changeGender(gender: string) {
        this.applicationUser.Gender = gender;
    }

    save() {
        if (this.dataValidator.IsValidObject(this.applicationUser)) {
            this.accountService.signup(this.applicationUser).subscribe(
                result => {
                    if (result != undefined) {
                        this.toastr.info(result);
                        this.router.navigate(["acc-cnf-email-sent"]);
                    }
                },
                () => {
                    this.router.navigate(["error"]);
                });
                //result => {
                //    if (result != undefined) {
                //        this.router.navigate(["/profile/interests"]);
                //    }
                //    else {
                //        this.router.navigate(["/error"]);
                //    }
                //},
                //error => {
                //});
        }
    }
}
