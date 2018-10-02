import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IAddress = App.Client.Profile.IAddressDto;import * as _ from "lodash";
;

@Component({
    selector: "profile-edit-address",
    templateUrl: "././profileEditAddress.component.html",
    styleUrls: ['././profileEditAddress.component.css']
})


export class ProfileEditAddressComponent {

    private addressReset: IAddress = {} as IAddress;
    public address: IAddress = {} as IAddress;

    constructor(
        private readonly router: Router,
        private readonly userProfileService: ProfileEditService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.userProfileService.GetUserCurrentAddress().subscribe(response => {
            if (response != null) {
                this.address = _.cloneDeep(response);
                this.addressReset = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result load(): ProfileEditAddressComponent");
            }
        });
    }

    save() {
        this.userProfileService.UpdateUserAddress(this.address).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.router.navigate(["/profile"]);
            }
            else {
                console.warn(response.statusText);
            }
        });
    }

    reset() {
        this.address = this.addressReset;
    }
}
