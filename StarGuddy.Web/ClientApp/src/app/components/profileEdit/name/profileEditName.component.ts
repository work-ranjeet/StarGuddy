import { Component } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserNameModel = App.Client.Profile.IUserNameModel;
import * as _ from 'lodash';
import { Router } from '@angular/router';



/** @title Simple form field */
@Component({
    selector: "profile-edit-name",
    templateUrl: "././profileEditName.component.html",
    styleUrls: ['././profileEditName.component.css']
})
export class ProfileEditNameComponent {

    public fullName: string = "Ranjeet Kumar";
    public shortName: string = "Ranjeet K";
    public userNameModel: IUserNameModel = {} as IUserNameModel;

    constructor(
        private readonly router: Router,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.profileService.GetUserNameDetail().subscribe(response => {
            if (response != null) {
                if (response.lastName == undefined || response.lastName == null) {
                    response.lastName = "";
                }

                this.userNameModel = _.cloneDeep(response);
                this.fullName = response.firstName + " " + response.lastName;
                this.shortName = response.firstName + " " + (response.lastName != "" ? response.lastName.slice(0, 1) : "");
            }
            else {
                console.info("Got empty result: IDancingModel");
            }
        });
    }

    save() {
        this.profileService.SaveUserNameDetail(this.userNameModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.router.navigate(["/profile"]);
            }
            else {
                console.warn("not updated: SaveUserNameDetail()");
            }
        });
    }


    firstNameChange(inputVal: string) {
        this.fullName = inputVal + " " + this.userNameModel.lastName;
        this.shortName = inputVal + " " + (this.userNameModel.lastName != "" ? this.userNameModel.lastName.slice(0, 1) : "");
    }

    lastNameChange(inputVal: string) {
        this.fullName = this.userNameModel.firstName + " " + inputVal;
        this.shortName = this.userNameModel.firstName + " " + (inputVal != "" ? inputVal.slice(0, 1) : "");
    }

}