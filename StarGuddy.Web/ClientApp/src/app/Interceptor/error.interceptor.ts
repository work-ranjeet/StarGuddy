//import { Injectable, Inject } from '@angular/core';
//import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
//import { Observable } from 'rxjs';

//import { BaseService } from '../Services/BaseService';


//@Injectable()
//export class ErrorInterceptor implements HttpInterceptor {

//    constructor(@Inject(BaseService) private readonly baseService: BaseService) { }

//    //intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//    //    //return next.handle(request).pipe(catchError(err => {
//    //    //    if (err.status === 401) {
//    //    //        // auto logout if 401 response returned from api
//    //    //        //this.authenticationService.logout();
//    //    //        //location.reload(true);
//    //    //    }

//    //    //    const error = err.error.message || err.statusText;
//    //    //    return throwError(error);
//    //    //}))      
//    //}

//    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//        return next.handle(req)
//            .catch(error => {
//                if (error instanceof HttpErrorResponse) {
//                    if (error.status === 401) {
//                        //this.accService.logOut();
//                        this.baseService.cancleAuthention();
//                        location.reload(true);
//                    }

//                    return Observable.throw(error.message || error.statusText);
//                }

//                return Observable.empty<HttpEvent<any>>();
//            });
//    }
//}
//}