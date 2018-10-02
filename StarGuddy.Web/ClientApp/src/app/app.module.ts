import { CommonModule } from "@angular/common";
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppIndexComponent } from "./components/appIndex/appIndex.component";
import { CommonModuleShared } from "./components/common/common.module.shared";
import { HomeModuleShared } from "./components/home/home.module.shared";
import { AccountModuleShared } from "./components/account/account.module.shared";

//// Providers
import { AppConstant, DbOperation } from "./Constants/AppConstant";
import { DataConverter } from "./Helper/DataConverter";
import { DataValidator } from "./Helper/DataValidator";
import { AuthGuard } from "./Services/AuthenticationGuard";
import { BaseService } from "./Services/BaseService";
import { HttpService } from "./Services/HttpClient";
import { ToastrService } from "./Services/ToastrService";

@NgModule({
    declarations: [
        AppIndexComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        CommonModule,
        CommonModuleShared,
        HomeModuleShared,
        AccountModuleShared,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "**", redirectTo: "home" }

        ])
    ],
    providers: [AppConstant, DbOperation, DataConverter, DataValidator, BaseService, AuthGuard, HttpService, ToastrService],
    bootstrap: [AppIndexComponent]
})
export class AppModule { }
