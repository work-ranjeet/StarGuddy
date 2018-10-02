import { Component } from "@angular/core";
import { Router } from "@angular/router";
import * as _ from "lodash";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "job-group",
    templateUrl: "./jobGroup.component.html",
    styleUrls: ["./jobGroup.component.css"]
})
export class JobGroupComponent {
    public userInterestList: Array<IJobGroupModel> = [];
    public userInterestResetList: Array<IJobGroupModel> = [];


    constructor(
        private readonly userProfileService: ProfileEditService,
        private readonly router: Router) {
        this.userProfileService = userProfileService;
    }

    ngOnInit() {
        this.loadUserInterests();
    }

    loadUserInterests() {
        this.userProfileService.GetUserInterestDetail().subscribe(response => {
            if (response != null) {
                this.userInterestList = _.cloneDeep(response);
                this.userInterestResetList = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result: JobGroupComponent.GetUserInterestDetail()");
            }
        });
    }

    updateSelectedJobGroup(checkEvent: any) {
        var checkboxIndex = this.userInterestList.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.userInterestList[checkboxIndex].selectedCode = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    saveChanges() {
        this.userProfileService.SaveUserInterestDetail(this.userInterestList).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");

                this.router.navigate(["/profile"]);
            }
            else {
                this.router.navigate(["/error"]);
            }
        });
    }

    reset() {
        this.userInterestList = _.cloneDeep(this.userInterestResetList);
    }
}
