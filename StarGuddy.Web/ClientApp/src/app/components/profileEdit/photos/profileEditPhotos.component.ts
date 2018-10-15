import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "profile-edit-photos",
    templateUrl: "././profileEditPhotos.component.html",
    styleUrls: ['././profileEditPhotos.component.css']
})


export class ProfileEditPhotosComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: ProfileEditService;

    constructor(userProfileService: ProfileEditService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
       
    }
        
}
