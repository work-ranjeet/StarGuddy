//import { Observable } from "rxjs/Observable";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;
import IUserData = App.Client.Account.IApplicationUser;


@Injectable()
export class ProfileSettingsService {

    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor( @Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) { }

    updateEmail(userEmail: IUserEmail) {
        return this.baseService.HttpService.post("Profile/Setting/UpdateEmail", userEmail);
    }


    //get IsLoggedIn() { return this.isLoggedInSource.asObservable(); }

    //get IsAuthenticated() { return this.baseService.IsAuthenticated; }

    //getUserFirstName(): string {
    //    return this.dataConverter.ConvertToString(this.baseService.UserFirstName);
    //}

    //login(loginData: ILoginData) {
    //    var v = "";
    //    return this.http.post(this.baseService.BaseApiUrl + "Account/login", loginData).map(response => {
    //        if (response.ok) {
    //            this.isLoggedInSource.next(true);
    //            this.baseService.authenticate(response);
    //        }
    //    });
    //}

    //logOut() {
    //    this.isLoggedInSource.next(false);
    //    this.baseService.cancleAuthention();
    //}

    //signup(userData: IUserData) {
    //    return this.http.post(this.baseService.BaseApiUrl + "Account/signup", userData).map(response => {
    //        if (response.ok) {
    //            this.isLoggedInSource.next(true);
    //            this.baseService.authenticate(response);
    //        }
    //    });
    //}

    //register(user) {
    //    delete user.confirmPassword;
    //    this.http.post(this.BASE_URL + "/register", user).subscribe(res => {
    //        this.authenticate(res);
    //    });
    //}
}
