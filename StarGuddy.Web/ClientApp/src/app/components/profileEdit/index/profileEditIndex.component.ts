import { Component } from "@angular/core";
import { ProfileIndexAbstract } from "../../comBase/profileIndexAbstract";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import * as _ from "lodash";

@Component({
    selector: "profile-edit-index",
    templateUrl: "././profileEditIndex.component.html",
    styleUrls: ['././profileEditIndex.component.css']
})

export class ProfileEditIndex extends ProfileIndexAbstract {
    public showLoadingSpinner: boolean = true;

    constructor(private readonly profileEditService: ProfileEditService) {
        super();
    }

    ngOnInit() {
        this.loadHeaderData();
    }

    loadHeaderData() {
        try {
            this.showLoadingSpinner = true;
            this.profileEditService.GetUserProfileHeader().subscribe(response => {
                if (response != null) {
                    this.ProfileHeader = _.cloneDeep(response);
                    this.AboutMe = _.cloneDeep(response.about);
                    this.SelectedGroups = _.cloneDeep(response.jobGroups);
                    this.LoadSection();
                    this.showLoadingSpinner = false;
                }
                else {
                    console.info("Got empty result: ProfileEditIndex.loadHeaderData()");
                }
            });
        } catch (e) {
            this.showLoadingSpinner = false;
            console.error(e);
        }
    }
}
