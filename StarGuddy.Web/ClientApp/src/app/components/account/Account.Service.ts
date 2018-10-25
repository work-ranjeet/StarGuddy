
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import "rxjs/add/operator/map";
import { Observable } from "rxjs/Observable";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import ILoginData = App.Client.Account.ILoginData;


@Injectable()
export class AccountService {

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) {
        this.IsAuthenticated ? baseService.isLoggedInSource.next(true) : baseService.isLoggedInSource.next(false);
    }

    get IsAuthenticated() { return this.baseService.IsAuthenticated; }

    getUserFirstName(): string {
        return this.dataConverter.ConvertToString(this.baseService.UserFirstName);
    }

    login(loginData: ILoginData): Observable<any> {
        return this.baseService.HttpService.postSimple("Account/login", loginData).map(response => {
            if (response != null && response.token != null && response.token != "") {
                this.baseService.authenticate(response);

                if (response.isEmailVerified) {
                    this.baseService.isLoggedInSource.next(true);
                }
            }

            return response;
        });
    }

    logOut() {
        this.baseService.isLoggedInSource.next(false);
        this.baseService.cancleAuthention();
    }

    signup(userData: any): Observable<any> {
        return this.baseService.HttpService.postSimple("Account/signup", userData).map(response => {
            return response;
        });
    }

    activateEmail(token: string): Observable<any> {
        return this.baseService.HttpService.putData<any>("Email/activate", { "AuthToken": token }).map(
            response => {
                return response;
            });
    };

    resendEmailActivationCode(userId: string): Observable<any> {
        return this.baseService.HttpService.putData<string>("Email/verify" , { UserId: userId }).map(
            response => {
                return response;
            });
    };
}
