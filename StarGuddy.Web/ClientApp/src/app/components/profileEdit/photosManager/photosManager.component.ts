import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import * as _ from 'lodash';
import { ToastrService } from '../../../Services/ToastrService';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserImageModel = App.Client.Profile.IUserImageModel;

@Component({
    selector: "profile-edit-photos-manager",
    templateUrl: "././photosManager.component.html",
    styleUrls: ['././photosManager.component.css']
})


export class ProfileEditPhotosManagerComponent {

    public resultCount: number = 0;
    public userImageModel: Array<IUserImageModel> = [];

    constructor(
        private toastr: ToastrService,
        private readonly router: Router,
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileEditService,
        public dialog: MatDialog) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.profileService.GetAllImages().subscribe(response => {
            if (response != null) {
                response.forEach(x => x.dataUrl = (x.dataUrl == null || x.dataUrl == "") ? x.imageUrl : x.dataUrl);
                this.userImageModel = _.cloneDeep(response);
                this.resultCount = this.userImageModel.length;
                //this.showImgeCropper = true;
            }
            else {
                console.info("Got empty result: ProfileEditPhotosManagerComponent.load()");
            }
        },
            error => {
                if (!error.ok && error.status == 404) {
                    this.userImageModel = [];
                    this.resultCount = 0;
                }
            }
        );
    }

    deleteImage(imageId: string) {
        try {            
            var actionResult = confirm("Do you want to delete this image?")
            if (actionResult) {
                this.profileService.DeleteImage(imageId).subscribe(response => {
                    if (response != null && response) {
                        this.toastr.success(response);
                    }
                    else {
                        this.toastr.warning("Oops! There is some issue, Please try later...");
                    }

                    this.load();
                });
            }
        } catch (e) {
            this.toastr.error(e.message);
        }
    }

    //openDialog(): void {
    //    let dialogRef = this.dialog.open(ProfileEditNameComponent, {
    //        width: '250px',
    //        data: { name: "", animal: "" }
    //    });

    //    dialogRef.afterClosed().subscribe(result => {
    //        console.log('The dialog was closed');
            
    //    });
    //}
}
