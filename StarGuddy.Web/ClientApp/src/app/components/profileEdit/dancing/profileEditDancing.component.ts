import { Component } from "@angular/core";
import * as _ from "lodash";
import { Expertlavel } from "../../../Enums/enums";
import { DataValidator } from "../../../Helper/DataValidator";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IDancingStyle = App.Client.Profile.IDancingStyleModel;
import IDancingModel = App.Client.Profile.IDancingModel;

@Component({
    selector: "profile-edit-dancing",
    templateUrl: "././profileEditDancing.component.html",
    styleUrls: ['././profileEditDancing.component.css']
})


export class ProfileEditDancingComponent {

    private readonly dataValidator: DataValidator;
    private readonly userProfileService: ProfileEditService;
    private readonly initDancingStyle = { id: "", name: "", selectedValue: 0, value: 0 } as IDancingStyle;
    private readonly initCreditsClass = { id: "", agentNeed: 0, choreographyAbilities: 0, danceAbilities: 0, dnacingStyles: Array<IDancingStyle>(), experience: "", isAgent: false, isAttendedSchool: true, userId: "" } as IDancingModel;

    public showDancing: boolean = false;
    public showEditHtml: boolean = false;
    public dancingModel: IDancingModel;
    public dancingResult: IDancingModel;
    public resultReset: IDancingModel;
    public dancingStyleList: Array<IDancingStyle> = [];

    constructor(userProfileService: ProfileEditService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.dancingModel = _.cloneDeep(this.initCreditsClass);
        this.dancingResult = _.cloneDeep(this.initCreditsClass);
        this.resultReset = _.cloneDeep(this.initCreditsClass);
    }

    ngOnInit() {
        this.loadDancingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    loadDancingDetails() {
        this.userProfileService.GetUserDanceDetail().subscribe(
            response => {
                if (response != null) {
                    this.dancingModel = _.cloneDeep(response);
                    this.dancingResult = _.cloneDeep(response);
                    this.resultReset = _.cloneDeep(response);
                    this.showDancing = true;
                }
            },
            err => {
                console.info(err.error);
                this.showDancing = false;
            });
    }

    updateSelectedDanceStyle(checkEvent: any) {
        var checkboxIndex = this.dancingModel.dnacingStyles.findIndex(x => x.value == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.dancingModel.dnacingStyles[checkboxIndex].selectedValue = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    onDanceExpertLavelGroupSelectionChange(expertLavel: any) {
        var expertLevelValue = parseInt(expertLavel.currentTarget.value);
        this.dancingModel.danceAbilities = expertLevelValue;

        this.dancingModel.danceAbilitiesText = Expertlavel[expertLevelValue];
    }

    teachingExpertLavelGroupSelectionChange(expertLavel: any) {
        var expertLevelValue = parseInt(expertLavel.currentTarget.value);
        this.dancingModel.choreographyAbilities = expertLevelValue;


        this.dancingModel.choreographyAbilitiesText = Expertlavel[expertLevelValue];
    }

    onAgentGroupSelectionChange(agentRequest: any) {
        var agentRequestlValue = parseInt(agentRequest.currentTarget.value);
        this.dancingModel.agentNeed = agentRequestlValue;
    }

    chkDanceSchoolChange() {
        this.dancingModel.isAttendedSchool = !this.dancingModel.isAttendedSchool;
    }

    saveChanges() {
        this.userProfileService.SaveUserDancingChanges(this.dancingModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.loadDancingDetails();
                this.showEditHtml = false;
            }
            else {
                console.warn(response.statusText);
            }
        });
    }

    resetChanges() {
        this.dancingModel = Object.assign({}, this.resultReset);
        this.dancingModel.dnacingStyles = Object.assign({}, this.resultReset.dnacingStyles);
    }
}
