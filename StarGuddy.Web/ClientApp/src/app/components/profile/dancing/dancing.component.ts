import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../../profile/profile.Service";
import IDancingModel = App.Client.Profile.IDancingModel;

@Component({
    selector: "profile-dancing",
    templateUrl: "././dancing.component.html"
})


export class ProfileDancingComponent {
    public dancingModel: IDancingModel = {} as IDancingModel;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        this.loadDancingDetails();   
    }

    loadDancingDetails() {
        this.profileService.GetUserDanceDetail().subscribe(response => {
            if (response != null) {
                this.dancingModel = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result: IDancingModel");
            }
        });
    }
}
