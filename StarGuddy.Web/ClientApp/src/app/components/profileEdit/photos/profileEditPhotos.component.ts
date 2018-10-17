import { Component } from "@angular/core";
import * as _ from 'lodash';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserImageModel = App.Client.Profile.IUserImageModel;

@Component({
    selector: "profile-edit-photos",
    templateUrl: "././profileEditPhotos.component.html",
    styleUrls: ['././profileEditPhotos.component.css']
})


export class ProfileEditPhotosComponent {
    public showPhotoSection: boolean = true;
    public userImageModel: Array<IUserImageModel> = [];

    constructor(private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.profileService.GetAllImages().subscribe(response => {
            if (response != null) {
                this.userImageModel = _.cloneDeep(response.filter(x => x.imageType != 1));
                this.showPhotoSection = this.userImageModel.length > 0;
            }
            else {
                console.info("Got empty result: ProfileEditPhotosComponent.load()");
            }
        },
            error => {
               this.userImageModel = [];
               this.showPhotoSection = false;
            }
        );
    }
}
