import { Component, EventEmitter, Output } from "@angular/core";
import * as _ from "lodash";
import { ActingExperiance } from "../../../Enums/enums";
import { DataValidator } from "../../../Helper/DataValidator";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";

import IActingDetailModel = App.Client.Profile.IUserActingModel;
import { ProfileEditMenu } from "../menu/profileEditMenu.component";

@Component({
    selector: "profile-edit-acting",
    templateUrl: "././profileEditActing.component.html",
    styleUrls: ['././profileEditActing.component.css']
})


export class ProfileEditActingComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: ProfileEditService;

    public showLanguage: boolean = true;
    public showAccents: boolean = true;
    public showActing: boolean = false;
    public showEditHtml: boolean = false;
    public actingDetailModel: IActingDetailModel;
    public actingDetailReset: IActingDetailModel;

    constructor(userProfileService: ProfileEditService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.actingDetailModel = _.cloneDeep({} as IActingDetailModel);
        this.actingDetailReset = _.cloneDeep({} as IActingDetailModel);
    }

    ngOnInit() {
        this.loadActingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
        this.resetChanges();
    }

    loadActingDetails() {
        this.userProfileService.GetUserActingDetail().subscribe(
            response => {
                if (response != null) {
                    this.filterResponse(response);
                    this.actingDetailModel = _.cloneDeep(response);
                    this.actingDetailReset = _.cloneDeep(response);
                    this.showActing = true;
                    this.showEditHtml = false;
                }
            },
            err => { this.showActing = false; console.error(err.error) });
    }

    filterResponse(response: IActingDetailModel) {
        if (response.actingExperiance == "") {
            response.actingExperianceCode = 200;
            response.actingExperiance = ActingExperiance[response.actingExperianceCode];
        }
        if (response.languages.length > 0 && response.languages.findIndex(x => x.selectedLanguageCode != "") < 0) {
            this.showLanguage = false;
        }

        if (response.accents.length > 0 && response.accents.findIndex(x => x.selectedAccent != "") < 0) {
            this.showAccents = false;
        }
    }

    updateSelectedJobGroup(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.auditionsAndJobsGroup.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.auditionsAndJobsGroup[checkboxIndex].selectedCode = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    updateSelectedLanguageChange(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.languages.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.languages[checkboxIndex].selectedLanguageCode = checkEvent.target.checked ? checkEvent.target.value : "";
        }
    }

    updateSelectedAccentChange(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.accents.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.accents[checkboxIndex].selectedAccent = checkEvent.target.checked ? checkEvent.target.value : "";
        }
    }

    onActingExpSelectionChange(checkEvent: any) {
        var actExpValue = parseInt(checkEvent.currentTarget.value);
        this.actingDetailModel.actingExperianceCode = actExpValue;
        this.actingDetailModel.actingExperiance = ActingExperiance[actExpValue];
    }

    onAgentGroupSelectionChange(checkEvent: any) {
        var agentValue = parseInt(checkEvent.currentTarget.value);
        this.actingDetailModel.agentNeedCode = agentValue;
    }

    resetChanges() {
        if (!this.showEditHtml) {
            this.actingDetailModel = _.cloneDeep({} as IActingDetailModel);
            this.actingDetailModel = _.cloneDeep(this.actingDetailReset);
        }
    }

    saveChanges() {
        this.userProfileService.SaveUserActingDetails(this.actingDetailModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.loadActingDetails();
            }
            else {
                console.warn(response.statusText);
            }           
        });
    }
}
