import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
    selector: 'account-signup',
    template: `<div class="container">
                    <div style="width:600px; padding-top:16%" class="margin-auto">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-6">                              
                                    <div (click)="loadPage('jobseeker')" style="background-color: #006684; border-radius:5px; padding:5px; color:white; cursor: pointer;">                                      
                                        <p style="padding: 10px;text-align: center;font-size: 22px; text-align: center;">Are you have talent?</p>
                                    </div>
                            </div>
                            <div class="col-sm-12  col-lg-6 col-md-6">
                                <div (click)="loadPage('jobprovider')" style="background-color: #006684; border-radius:5px; padding:5px; color:white; cursor: pointer;">                                      
                                        <p style="padding: 10px;text-align: center;font-size: 22px; text-align: center;">Are you searching for talent?</p>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>`
})

export class SignUpComponent {

    constructor(private readonly router: Router) { }

    ngOnInit() { }

    loadPage(value: string) {
        this.router.navigate(["/" + value]);
    }
}

//<div style="height: 30px; font-size: 22px;" >
//    <i class="glyphicon glyphicon-globe" style = "font-size:22px; float:left; padding-top: 5px;" > </i>
//        <span>& nbsp; Talent Directory < /span>
//            < /div>
//            < hr style = "margin-top:5px; margin-bottom:5px;" />




//<div style="height: 30px; font-size: 22px;" >
//    <i class="glyphicon glyphicon-bullhorn" style = "font-size:22px; float:leftpadding-top: 5px; " > </i>
//        <span>& nbsp; Talent Search < /span>
//            < /div>
//            < hr style = "margin-top:5px; margin-bottom:5px;" />
