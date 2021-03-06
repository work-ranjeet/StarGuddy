import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import * as _ from "lodash";
import { ProfileIndexAbstract } from "../../comBase/profileIndexAbstract";
import { ProfileService } from "../../profile/profile.Service";
@Component({
    selector: "profile-index",
    templateUrl: "././index.component.html",
    styleUrls: ['././index.component.css']
})


export class ProfileIndex extends ProfileIndexAbstract {
    public showLoadingSpinner: boolean = true;

    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileService) { super(); }

    ngOnInit() {
        this.activatedRoute.params.subscribe(param => this.profileService.ProfileUrl = param['profileUrl']);
        this.loadHeaderData();
    }

    loadHeaderData() {
        try {
            this.showLoadingSpinner = true;
            this.profileService.GetUserProfileHeader().subscribe(response => {
                if (response != null) {
                    this.ProfileHeader = _.cloneDeep(response);
                    this.AboutMe = _.cloneDeep(response.about);
                    this.SelectedGroups = _.cloneDeep(response.jobGroups);
                    this.LoadSection();
                    this.showLoadingSpinner = false;
                }
                else {
                    console.info("Got empty result: ProfileIndex.loadHeaderData()");
                }
            });
        } catch (e) {
            this.showLoadingSpinner = false;
            console.error(e);
        }
    }
}

