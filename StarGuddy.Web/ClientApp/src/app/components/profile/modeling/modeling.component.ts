import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../profile.Service";
import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import { ModelingExperiance } from "../../../Enums/enums";

@Component({
    selector: "profile-modeling",
    templateUrl: "././modeling.component.html"
})


export class ProfileModelingComponent {
    public showExperiance: boolean = true;
    public showWebsite: boolean = true;

    public modelingDetailModel: IModelingDetailModel = {} as IModelingDetailModel;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        this.loadModelingDetails();
    }


    loadModelingDetails() {
        this.profileService.GetUserModelingDetail().subscribe(
            response => {
                if (response != null) {
                    this.filterResponse(response);
                    this.modelingDetailModel = _.cloneDeep(response);
                }
            },
            err => { console.error(err.error); });
    }

    filterResponse(response: IModelingDetailModel) {
        if (response.expText == "" || response.expText == null) {
            response.expCode = 300;
            response.expText = ModelingExperiance[response.expCode];
        }

        if (response.webSite == "" || response.webSite == null) {
            this.showWebsite = false;
        }

        if (response.experiance == "" || response.experiance == null) {
            this.showExperiance = false;
        }
    }
}
