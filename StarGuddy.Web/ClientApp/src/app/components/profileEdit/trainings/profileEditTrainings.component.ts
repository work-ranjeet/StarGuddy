import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "profile-edit-trainings",
    templateUrl: "././profileEditTrainings.component.html",
    styleUrls: ['././profileEditTrainings.component.css']
})


export class ProfileEditTrainingsComponent {
    private readonly dataValidator: DataValidator;
    private userProfileService: ProfileEditService;

    public showEditHtml: boolean = false;

    constructor(userProfileService: ProfileEditService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }


    edit() {
        this.showEditHtml = !this.showEditHtml;
    }
    
}
