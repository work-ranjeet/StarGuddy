import { Component } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserDetailModel = App.Client.Profile.IUserDetailModel;
import * as _ from 'lodash';
import { Router } from '@angular/router';



/** @title Simple form field */
@Component({
    selector: "profile-edit-intro",
    templateUrl: "././profileEditIntro.component.html",
    styleUrls: ['././profileEditIntro.component.css']
})
export class ProfileEditIntroComponent {

    public userDetailModel: IUserDetailModel = {} as IUserDetailModel;
    private userDetailReset: IUserDetailModel = {} as IUserDetailModel;

    constructor(
        private readonly router: Router,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.profileService.GetUserDetail().subscribe(response => {
            if (response != null) {
                this.userDetailModel = _.cloneDeep(response);
                this.userDetailReset = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result: ProfileEditIntroComponent.GetUserDetail()");
            }
        });
    }

    save() {
        this.profileService.SaveUserIntro(this.userDetailModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.router.navigate(["/profile"]);
            }
            else {
                console.warn(response.statusText);
            }
        });
    }
}