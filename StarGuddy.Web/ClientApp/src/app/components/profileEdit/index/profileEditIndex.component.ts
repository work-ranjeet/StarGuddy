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

    constructor(private readonly profileEditService: ProfileEditService) {
        super();
    }

    ngOnInit() {
        //this.setToTop();
        this.loadHeaderData();
    }

    loadHeaderData() {
        this.profileEditService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.ProfileHeader = _.cloneDeep(response);
                this.AboutMe = _.cloneDeep(response.about);
                this.SelectedGroups = _.cloneDeep(response.jobGroups);
                this.FilterData(response.jobGroups);
                this.LoadSection();
            }
            else {
                console.info("Got empty result: ProfileEditIndex.loadHeaderData()");
            }
        });
    } 

}
