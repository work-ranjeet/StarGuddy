import { Component, Input } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import * as _ from 'lodash';
import { Router, ActivatedRoute } from '@angular/router';
import IUserImageModel = App.Client.Profile.IUserImageModel;
import { HttpEventType, HttpEvent } from '@angular/common/http';
import { ImageCroppedEvent } from 'ngx-image-cropper/src/image-cropper.component';
import { ToastrService } from '../../../Services/ToastrService';


/** @title Simple form field */
@Component({
    selector: "profile-photo-upload",
    templateUrl: "././photoUpload.component.html",
    styleUrls: ['././photoUpload.component.css']
})
export class ProfilePhotoUploadComponent {
    public showImage: boolean = false;
    public isLeftRotating: boolean = false;
    public isRightRotating: boolean = false;

    public progress: number = 0;
    public message: string = "";

    public coordinates: any = { x: 0 };
    public cropperBase64: any;

   
    private fileToUpload: File = {} as File;
    private fileReader: FileReader = new FileReader();
    public userImageModel: IUserImageModel = {} as IUserImageModel;

    constructor(
        private toastr: ToastrService,
        private readonly router: Router,
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.reset();
        this.fileReader.onload = (event: any) => {
            this.userImageModel.dataUrl = event.target.result;
            this.cropperBase64 = event.target.result;
        };
    }

    reset() {
        this.showImage = false;
        this.cropperBase64 = "";
        this.progress = 0;
        this.message = "";
        this.fileToUpload = {} as File;
    }

    imageCropped(event: ImageCroppedEvent) {
        this.userImageModel.dataUrl = event.base64;
    }

    handleFileInput(event: any) {
        var files = (event.target.files) as FileList;
        if (files.length > 0) {
            var file = files.item(0);
            if (file != null) {
                this.fileToUpload = file;
                this.userImageModel.name = file.name;
                this.userImageModel.size = file.size;
                this.fileReader.readAsDataURL(this.fileToUpload);
            }

            this.showImage = true;
        }
    }

    uploadImage() {
        this.userImageModel.imageType = 2;
        this.profileService.UploadImage(this.userImageModel).subscribe((event: any) => {
            if (event.type === HttpEventType.UploadProgress)
                this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response) {
                this.toastr.success(event.body.toString());
                this.router.navigate(['/profile/photoManager']);
                //this.message = event.body.toString();
            }
        });
    }
    

    rotate(isClockwise: boolean) {
        var sup = this;  
        this.isRightRotating = !isClockwise;
        this.isLeftRotating = isClockwise;
        if (!this.userImageModel.dataUrl) return;        
        this.rotateBase64Image(this.cropperBase64, isClockwise, function (result) {
            sup.cropperBase64 = result;
            sup.isRightRotating = false;
            sup.isLeftRotating = false;
        });
    }

    rotateBase64Image(base64data: any, isClockwise: boolean, callback: any) {
        var image = new Image();
        image.onload = function () {
            var canvas = document.createElement('canvas');
            canvas.width = image.height;
            canvas.height = image.width;
            var ctx = canvas.getContext("2d");
            var deg = isClockwise ? Math.PI / 2 : Math.PI / -2;
            ctx.translate(canvas.width / 2, canvas.height / 2);
            ctx.rotate(deg);
            ctx.drawImage(image, -image.width / 2, -image.height / 2);

            ctx.rotate(-deg);
            ctx.translate(-canvas.width / 2, -canvas.height / 2);
            callback(canvas.toDataURL());
        };
        image.crossOrigin = "Anonymous";
        image.src = base64data;
    }
}
