import { Component, Input } from "@angular/core";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-header",
    templateUrl: "././header.component.html",
    styleUrls: ['././header.component.css']
})


export class ProfileHeader {
    public imageUrl: string = "";
    public _jobGroupName: string = "";   
    public _profileHeader: IProfileHeader = {} as IProfileHeader

    public showAddress: boolean = false;
    public computedAddress: string = "Address not update.";

    @Input()
    set jobGroupNames(jobGroupNames: string) { this._jobGroupName = jobGroupNames; }
    get jobGroupNames(): string { return this._jobGroupName; }

    @Input()
    set profileHeader(profileHeader: IProfileHeader) {
        if (JSON.stringify(profileHeader) != "{}") {
            this._profileHeader = profileHeader;

            this.showAddress = profileHeader.cityOrTown != null && profileHeader.stateOrProvince != null && profileHeader.country != null;
            this.computedAddress = profileHeader.cityOrTown + ", " + profileHeader.stateOrProvince + ", " + profileHeader.country;

            this.imageUrl = profileHeader.dataUrl == "" ? profileHeader.imageUrl : profileHeader.dataUrl;
        }
    }
    get profileHeader() { return this._profileHeader; }
}
