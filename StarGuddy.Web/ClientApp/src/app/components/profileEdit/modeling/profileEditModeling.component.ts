import { Component } from "@angular/core";
import * as _ from "lodash";
import { ModelingExperiance } from "../../../Enums/enums";
import { DataValidator } from "../../../Helper/DataValidator";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";

import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import IAuditionsAndJobsGroup = App.Client.Profile.IAuditionsAndJobsGroup;

@Component({
    selector: "profile-edit-modeling",
    templateUrl: "././profileEditModeling.component.html",
    styleUrls: ['././profileEditModeling.component.css']
})


export class ProfileEditModelingComponent {
    private readonly dataValidator: DataValidator;
    private profileEditService: ProfileEditService;

    public showExperiance: boolean = true;
    public showWebsite: boolean = true;
    public showEditHtml: boolean = false;
    public modelingDetailModel: IModelingDetailModel;
    public modelingDetailReset: IModelingDetailModel;

    constructor(profileEditService: ProfileEditService, dataValidator: DataValidator) {
        this.profileEditService = profileEditService;
        this.dataValidator = dataValidator;
        this.modelingDetailModel = _.cloneDeep({} as IModelingDetailModel);
        this.modelingDetailReset = _.cloneDeep({} as IModelingDetailModel);
    }

    ngOnInit() {
        this.loadModelingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    loadModelingDetails() {
        this.profileEditService.GetUserModelingDetail().subscribe(
            response => {
                if (response != null) {
                    this.filterResponse(response);
                    this.modelingDetailModel = _.cloneDeep(response);
                    this.modelingDetailReset = _.cloneDeep(response);
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

    updateSelectedJobGroup(checkEvent: any) {
        var checkboxIndex = this.modelingDetailModel.modelingRoles.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.modelingDetailModel.modelingRoles[checkboxIndex].selectedCode = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    onModelingExpSelectionChange(checkEvent: any) {
        var expValue = parseInt(checkEvent.currentTarget.value);
        this.modelingDetailModel.expCode = expValue;
        this.modelingDetailModel.expText = ModelingExperiance[expValue];
    }

    onAgentGroupSelectionChange(checkEvent: any) {
        var agentValue = parseInt(checkEvent.currentTarget.value);
        this.modelingDetailModel.agentNeedCode = agentValue;
    }

    resetChanges() {
        if (!this.showEditHtml) {
            this.modelingDetailModel = _.cloneDeep({} as IModelingDetailModel);
            this.modelingDetailModel = _.cloneDeep(this.modelingDetailReset);
        }
    }

    saveChanges() {
        this.profileEditService.SaveUserModelingDetails(this.modelingDetailModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.loadModelingDetails();
            }
            else {
                console.warn(response.statusText);
            }

            this.showEditHtml = false;
        });
    }
}
