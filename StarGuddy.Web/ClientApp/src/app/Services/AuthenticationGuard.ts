import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, CanActivateChild } from "@angular/router";
import { BaseService } from "./BaseService";

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild  {

    constructor(
        private readonly router: Router,
        private readonly baseService: BaseService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.baseService.IsAuthenticated) {
            return true;
        }
        else {
            this.baseService.cancleAuthention();
            this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
        }

        return false;
    }

    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.baseService.IsAuthenticated) {
            return true;
        }
        else {
            this.baseService.cancleAuthention();
            this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
        }

        return false;
    }
}