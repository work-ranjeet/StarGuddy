import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { CommonModuleShared } from "../common/common.module.shared";

import { ProfileSettingsService } from "./profileSettings.Service";

import { AddEmailComponent } from "./addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./changeAddress/changeAddress.component";
import { ChangePwdComponent } from "./changePassword/changePwd.component";
import { ChangeEmailComponent } from "./changeEmail/changeEmail.component";
import { VerifyPhoneNumberComponent } from "./verifyPhoneNumber/verifyPhoneNumber.component";
import { UserProfileSettingsIndex } from "./userProfileSettingsIndex/userProfileSettingsIndex.component";
import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";
import { AuthGuard } from "../../Services/AuthenticationGuard";

@NgModule({
    declarations: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        ChangeEmailComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ],
    imports: [
        CommonModule,
        FormsModule,
        CommonModuleShared,
        RouterModule.forRoot([
            {
                path: "profileSetting",
                canActivate: [AuthGuard],
                children: [
                    { path: "", component: UserProfileSettingsIndex },
                    { path: "addEmail", component: AddEmailComponent, canActivateChild: [AuthGuard] },
                    { path: "addPhoneNumber", component: AddPhoneNumberComponent, canActivateChild: [AuthGuard] },
                    { path: "changeAddress", component: ChangeAddressComponent, canActivateChild: [AuthGuard] },
                    { path: "changePwd", component: ChangePwdComponent, canActivateChild: [AuthGuard] },
                    { path: "changeEmail", component: ChangeEmailComponent, canActivateChild: [AuthGuard] },
                    { path: "verifyPhoneNumber", component: VerifyPhoneNumberComponent, canActivateChild: [AuthGuard] }
                ]
            }
        ])
    ],
    providers: [ProfileSettingsService],
    exports: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        ChangeEmailComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ]
})

export class ProfileSettingModuleShared {
}
