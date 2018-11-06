import { isPlatformBrowser } from "@angular/common";
import { Inject, Injectable, PLATFORM_ID } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, BehaviorSubject } from "rxjs";
import { AppConstant } from "../Constants/AppConstant";
import { HttpService } from "../Services/HttpClient";

@Injectable()
export class BaseService {
    public isLoggedInSource = new BehaviorSubject<boolean>(false);

    private readonly httpService: HttpService;
    private readonly appConstant: AppConstant;

    constructor(
        @Inject(HttpService) httpService: HttpService,
        @Inject(PLATFORM_ID) private platformId: Object,
        appConstant: AppConstant, router: Router) {
        this.httpService = httpService;
        this.appConstant = appConstant;
        this.isLoggedInSource.next(this.IsAuthenticated);
    }
      

    get IsLoggedIn(): Observable<boolean> { return this.isLoggedInSource.asObservable(); }

    get IsAuthenticated(): boolean {
        var token = isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.TOKEN_KEY) : "";
        return token != undefined && token != null && token.length > 0;
    }

    get UserName() {
        return isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.USER_NAME) : "";
    }

    get UserFirstName() {
        return isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.USER_FIRST_NAME) : "";
    }

    get HttpService(): HttpService {
        return this.httpService;
    }

    authenticate(result: any): void {
        const authResponse = result;
        if (isPlatformBrowser(this.platformId)) {
            sessionStorage.setItem(this.appConstant.TOKEN_KEY, authResponse.token);
            sessionStorage.setItem(this.appConstant.USER_FIRST_NAME, authResponse.firstName);
        }
    }

    cancleAuthention() {
        if (isPlatformBrowser(this.platformId)) {
            sessionStorage.clear();
            this.isLoggedInSource.next(false);
        }
    }

}
