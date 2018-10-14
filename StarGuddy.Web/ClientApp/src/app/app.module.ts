import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ToastModule, ToastOptions } from "ng5-toastr";

import { ProfileModuleShared } from "../app/components/profile/profile.module.shared";
import { ProfileEditModuleShared } from "../app/components/profileEdit/profileEdit.module.shared";
import { ProfileSettingModuleShared } from "../app/components/profileSettings/profileSettings.module.shared";
import { SearchModuleShared } from "../app/components/search/search.module.shared";
import { AppIndexComponent } from "./appIndex/appIndex.component";
import { AccountModuleShared } from "./components/account/account.module.shared";
import { CommonModuleShared } from "./components/common/common.module.shared";
import { HomeModuleShared } from "./components/home/home.module.shared";


//// Providers
import { AppConstant, DbOperation } from "./Constants/AppConstant";
import { DataConverter } from "./Helper/DataConverter";
import { DataValidator } from "./Helper/DataValidator";
import { JwtInterceptor } from "./Interceptor/jwt.interceptor";
import { AuthGuard } from "./Services/AuthenticationGuard";
import { BaseService } from "./Services/BaseService";
import { HttpService } from "./Services/HttpClient";
import { ToastrService, ToasterOption } from "./Services/ToastrService";

@NgModule({
    declarations: [
        AppIndexComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), BrowserAnimationsModule,
        HttpClientModule, CommonModule,
        CommonModuleShared, HomeModuleShared, AccountModuleShared,
        ProfileModuleShared, ProfileEditModuleShared, ProfileSettingModuleShared,
        SearchModuleShared,
        ToastModule.forRoot(),
        RouterModule.forRoot([
            { path: "", redirectTo: "/home", pathMatch: "full" },
            { path: "**", redirectTo: "/home" }

        ])
    ],
    providers: [AppConstant, DbOperation, DataConverter, DataValidator, BaseService, AuthGuard, HttpService, ToastModule,
        ToastrService, { provide: ToastOptions, useClass: ToasterOption },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        }],
    bootstrap: [AppIndexComponent]
})
export class AppModule { }
