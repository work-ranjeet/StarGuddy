import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from '../../../Services/BaseService';

@Component({
    selector: 'log-in-out',
    templateUrl: './logInOut.component.html',
    styleUrls: ['./logInOut.component.css']
})

export class LogInOutComponent {

    public isLoggedIn: boolean = false;
    public showUserSettingMenu: boolean = true;
    public subscription: any;
    private router: Router;
    private baseService: BaseService;

    constructor(router: Router, baseService: BaseService) { this.router = router; this.baseService = baseService; }
    
    ngOnInit() {
        this.subscription = this.baseService.IsLoggedIn.subscribe((val: boolean) => this.isLoggedIn = val);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    get UserFirstName() { return this.baseService.UserFirstName; }


    toggleUserSettingMenu() {
        this.showUserSettingMenu = !this.showUserSettingMenu;
    }
    
    logOut() {
        this.baseService.isLoggedInSource.next(false);
        this.baseService.cancleAuthention();
        this.subscription.unsubscribe();
        this.router.navigate(['/']);
    }
}
