import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataValidator } from "../../../Helper/DataValidator";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";

@Component({
    selector: "user-profile-setting-index",
    templateUrl: "././userProfileSettingsIndex.component.html",
    styleUrls: ['././userProfileSettingsIndex.component.css']
})


export class UserProfileSettingsIndex {

    constructor(
        private readonly router: Router,
        private readonly authRoute: ActivatedRoute,
        private readonly dataValidator: DataValidator,
        private readonly profileSettingService: ProfileSettingsService) { }

    ngOnInit() {
    }
}
