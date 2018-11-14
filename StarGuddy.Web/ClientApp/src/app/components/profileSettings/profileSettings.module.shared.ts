import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthGuard } from "../../Services/AuthenticationGuard";
import { CommonModuleShared } from "../common/common.module.shared";
import { AddEmailComponent } from "./addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./changeAddress/changeAddress.component";
import { ChangeEmailComponent } from "./changeEmail/changeEmail.component";
import { ChangePwdComponent } from "./changePassword/changePwd.component";
import { ProfileSettingsService } from "./profileSettings.Service";
import { UserProfileSettingsIndex } from "./userProfileSettingsIndex/userProfileSettingsIndex.component";
import { VerifyPhoneNumberComponent } from "./verifyPhoneNumber/verifyPhoneNumber.component";
import { MatRadioModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule } from "@angular/material";


//import { MatRadioModule } from "@angular/material";

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
        FormsModule, ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
        MatRadioModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule,
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
