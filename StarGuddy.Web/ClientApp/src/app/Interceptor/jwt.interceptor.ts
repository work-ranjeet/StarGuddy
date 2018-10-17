import { isPlatformBrowser } from "@angular/common";
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Inject, Injectable, PLATFORM_ID } from "@angular/core";
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { AppConstant } from "../Constants/AppConstant";
import { Router } from "@angular/router";
import { BaseService } from "../Services/BaseService";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(
        @Inject(PLATFORM_ID) private platformId: Object,
        private readonly router: Router,
        private readonly baseService: BaseService,
        private appConstant: AppConstant) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        try {
            let token = isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.TOKEN_KEY) : "";
            if (token != undefined && token != null) {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${token}`
                    }
                });
            }

            return next.handle(request)
                .catch((error: any) => {
                    if (error instanceof HttpErrorResponse) {
                        if (error.status === 401) {
                            console.info(error.statusText); //Unauthorized Error response
                            this.baseService.isLoggedInSource.next(false);
                            this.baseService.cancleAuthention();
                            this.router.navigate(['/login']);
                            return Observable.throw(error);
                        }
                    };
                });
        }
        catch (er) {
            console.error(er);
        }
    }
}
