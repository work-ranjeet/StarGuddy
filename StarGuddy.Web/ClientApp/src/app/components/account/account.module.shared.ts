import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatStepperModule, MatInputModule, MatButtonModule, MatAutocompleteModule, MatCardModule, MatCheckboxModule, MatSelectModule } from "@angular/material";
import { CommonModuleShared } from "../common/common.module.shared";

import { AccountService } from "./Account.Service";
import { AccountLoginComponent } from "./login/login.component";
import { SignUpComponent } from "./signup/signup.component";


import { AccountConfirmEmailComponent } from "./confirmEmail/confirmEmail.component";
import { AccountConfirmEmailSentComponent } from "./confirmEmail/confirmEmailSent.component";
//import { AccountForgotPwdComponent } from "./forgotPwd/forgotPwd.component";
//import { AccountSendCodeComponent } from "./sendCode/sendCode.component";
//import { AccountVerifyCodeComponent } from "./verifyCode/verifyCode.component";


@NgModule({
    declarations: [
        AccountLoginComponent,
        SignUpComponent,
        AccountConfirmEmailComponent,
        AccountConfirmEmailSentComponent
        //AccountForgotPwdComponent
        //AccountSendCodeComponent,
        //AccountVerifyCodeComponent
    ],
    imports: [
        CommonModule, CommonModuleShared,
        FormsModule, ReactiveFormsModule,
        MatStepperModule, MatInputModule, MatButtonModule, MatAutocompleteModule, MatCardModule, MatCheckboxModule, MatSelectModule,
        RouterModule.forRoot([
            { path: "login", component: AccountLoginComponent },
            { path: "signup", component: SignUpComponent },
            { path: "acc-cnf-email/:code", component: AccountConfirmEmailComponent },
            { path: "acc-cnf-email-sent/:firstName/:id", component: AccountConfirmEmailSentComponent }
            //{ path: "acc-forgot-pwd", component: AccountForgotPwdComponent }
            //{ path: "acc-send-code", component: AccountSendCodeComponent },
            //{ path: "acc-verify-code", component: AccountVerifyCodeComponent }
        ])
    ],
    providers: [AccountService],
    exports: [
        AccountLoginComponent,
        SignUpComponent,
        AccountConfirmEmailComponent,
        AccountConfirmEmailSentComponent
        //AccountForgotPwdComponent
        //AccountSendCodeComponent,
        //AccountVerifyCodeComponent
    ]
})

export class AccountModuleShared {
}
