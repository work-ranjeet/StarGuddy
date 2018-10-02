import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { AccountService } from "./Account.Service";
import { AccountLoginComponent } from "./login/login.component";
import { SignUpComponent } from "./signup/signup.component";
import { SignUpJobProviderComponent } from "./signup/jobProvider/jobProvider.component";
import { SignUpJobSeekerComponent } from "./signup/jobSeeker/jobSeeker.component";



import { AccountConfirmEmailComponent } from "./confirmEmail/confirmEmail.component";
import { AccountConfirmEmailSentComponent } from "./confirmEmail/confirmEmailSent.component";
//import { AccountForgotPwdComponent } from "./forgotPwd/forgotPwd.component";
//import { AccountSendCodeComponent } from "./sendCode/sendCode.component";
//import { AccountVerifyCodeComponent } from "./verifyCode/verifyCode.component";


@NgModule({
    declarations: [
        AccountLoginComponent,
        SignUpComponent,
        SignUpJobProviderComponent,
        SignUpJobSeekerComponent,
        AccountConfirmEmailComponent,
        AccountConfirmEmailSentComponent
        //AccountForgotPwdComponent
        //AccountSendCodeComponent,
        //AccountVerifyCodeComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "login", component: AccountLoginComponent },
            { path: "signup", component: SignUpComponent },
            { path: "jobseeker", component: SignUpJobSeekerComponent },
            { path: "jobprovider", component: SignUpJobProviderComponent },
            { path: "acc-cnf-email", component: AccountConfirmEmailComponent },
            { path: "acc-cnf-email-sent", component: AccountConfirmEmailSentComponent }
            //{ path: "acc-forgot-pwd", component: AccountForgotPwdComponent }
            //{ path: "acc-send-code", component: AccountSendCodeComponent },
            //{ path: "acc-verify-code", component: AccountVerifyCodeComponent }
        ])
    ],
    providers: [AccountService],
    exports: [
        AccountLoginComponent,
        SignUpComponent,
        SignUpJobProviderComponent,
        SignUpJobSeekerComponent,
        AccountConfirmEmailComponent,
        AccountConfirmEmailSentComponent
        //AccountForgotPwdComponent
        //AccountSendCodeComponent,
        //AccountVerifyCodeComponent
    ]
})

export class AccountModuleShared {
}
