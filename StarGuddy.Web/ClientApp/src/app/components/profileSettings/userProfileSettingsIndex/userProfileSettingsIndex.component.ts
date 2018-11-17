import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import * as _ from "lodash";
import { DataValidator } from "../../../Helper/DataValidator";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import IUserSetting = App.Client.Profile.Setting.IUserSettingDto;
import IVisibilityGroup = App.Client.Profile.Setting.IVisibilityGroupDto;

@Component({
    selector: "user-profile-setting-index",
    templateUrl: "././userProfileSettingsIndex.component.html",
    styleUrls: ['././userProfileSettingsIndex.component.css']
})


export class UserProfileSettingsIndex {

    public userSettings: IUserSetting = {} as IUserSetting;
    public visibilityGroupList: Array<IVisibilityGroup> = [];

    constructor(
        private readonly router: Router,
        private readonly authRoute: ActivatedRoute,
        private readonly dataValidator: DataValidator,
        private readonly profileSettingService: ProfileSettingsService) { }

    ngOnInit() {
        this.loadUserSettings();
    }

    loadUserSettings() {
        this.profileSettingService.GetUserSettings().subscribe(response => {
            if (response != null) {
                this.userSettings = _.cloneDeep(response);
                this.visibilityGroupList = _.cloneDeep(response.visibilityGroups);
            }
            else {
                console.info("Got empty result: UserProfileSettingsIndex.loadUserSettings()");
            }
        });
    }

    showHideMobile(checkEvent: any) {
        console.info(checkEvent.target.value);
    }

    showHideEmail(checkEvent: any) {
        console.info(checkEvent.target.value);
    }

    showHideProfilePhoto(checkEvent: any) {
        console.info(checkEvent.target.value);
    }

    allowCommentOnProfileChange(checkEvent: any) {
        console.info(checkEvent.target.value);
    }

    enableDisabelTowFactorAuth(checkEvent: any) {
        console.info(checkEvent.target.value);
    }
}
