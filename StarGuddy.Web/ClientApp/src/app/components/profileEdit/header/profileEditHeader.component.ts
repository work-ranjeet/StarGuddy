import { Component, Input } from "@angular/core";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-edit-header",
    templateUrl: "././profileEditHeader.component.html",
    styleUrls: ['././profileEditHeader.component.css']
})


export class ProfileEditHeader {

    public imageUrl: string = "";
    public computedAddress: string = "Address not update.";
    private _jobGroupName: string = "";
    private _profileHeader: IProfileHeader = {} as IProfileHeader

    @Input()
    set jobGroupNames(jobGroupNames: string) { this._jobGroupName = jobGroupNames; }
    get jobGroupNames(): string { return this._jobGroupName; }

    @Input()
    set profileHeader(profileHeader: IProfileHeader) {
        if (JSON.stringify(profileHeader) != "{}") {
            this._profileHeader = profileHeader;

            this.computedAddress = profileHeader.cityOrTown != null && profileHeader.stateOrProvince != null && profileHeader.country != null ?
                profileHeader.cityOrTown + ", " + profileHeader.stateOrProvince + ", " + profileHeader.country : "Address not update.";

            this.imageUrl = profileHeader.dataUrl == "" ? profileHeader.imageUrl : profileHeader.dataUrl;
            var v = "";
        }
    }
    get profileHeader() { return this._profileHeader; }
}
