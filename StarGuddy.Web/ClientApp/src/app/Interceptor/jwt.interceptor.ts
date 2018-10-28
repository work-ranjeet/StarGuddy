import { isPlatformBrowser } from "@angular/common";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Inject, Injectable, PLATFORM_ID } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from 'rxjs/Observable';
import { AppConstant } from "../Constants/AppConstant";
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

            return next.handle(request);
                //.catch((error: any) => {
                //    if (error instanceof HttpErrorResponse) {
                //        if (error.status === 401) {
                //            console.info(error.statusText); //Unauthorized Error response
                //            this.baseService.isLoggedInSource.next(false);
                //            this.baseService.cancleAuthention();
                //            this.router.navigate(['/login']);
                //        }
                //    };

                //    console.error(error.status);
                //});
        }
        catch (er) {
            console.error(er);
        }
    }
}
