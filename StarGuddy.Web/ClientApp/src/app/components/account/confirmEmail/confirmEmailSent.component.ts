import { Component, Input } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: "account-confirm-email-sent",
    template: `<div style="padding-top:140px;">
                    <div class="container-box">
                        <strong class="text-info">We sent you verification link to your email. Please verify it to proceed....</strong>
                        <div style="width:100px; margin:auto; margin-top: 40px;">
                            <a href="https://mail.google.com/mail/u/0/#inbox" target="_blank" class="btn btn-success display-bloack">Go to Gmail</a>
                        </div>  
                   </div>
                </div>`
})

export class AccountConfirmEmailSentComponent {
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    @Input() public message: string | undefined;


    constructor(router: Router, authRoute: ActivatedRoute) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }   
}
