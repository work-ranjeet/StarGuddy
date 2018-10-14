import { Component, Input } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import * as _ from 'lodash';
import { Router, ActivatedRoute } from '@angular/router';
import IHeadShot = App.Client.Profile.IImageModel;
import { HttpEventType, HttpEvent } from '@angular/common/http';
import { ImageCroppedEvent } from 'ngx-image-cropper/src/image-cropper.component';
import { ToastrService } from '../../../Services/ToastrService';


/** @title Simple form field */
@Component({
    selector: "profile-head-shot",
    templateUrl: "././headShot.component.html",
    styleUrls: ['././headShot.component.css']
})
export class ProfileHeadShotComponent {
    private _gender: string = "";
    public isLeftRotating: boolean = false;
    public isRightRotating: boolean = false;
    public showImgeCropper: boolean = false;

    public progress: number = 0;
    public message: string = "";

    public coordinates: any = { x: 0 };
    //public imageChangedEvent: any = '';
    public croppedImage: any = '';
    public cropperBase64: any;

    //private imageUrl: string = "/css/icons/mail.png";
    private fileToUpload: File = {} as File;
    private fileReader: FileReader = new FileReader();
    public headShotModel: IHeadShot = {} as IHeadShot;

    @Input()
    set Gender(gender: string) { this._gender = gender; }
    get Gender(): string { return this._gender; }

    constructor(
        private toastr: ToastrService,
        private readonly router: Router,
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.showImgeCropper = false;
        this.activatedRoute.params.subscribe(param => this.Gender = param['gender']);
        this.fileReader.onload = (event: any) => {
            this.headShotModel.dataUrl = event.target.result;
            this.cropperBase64 = event.target.result;
        };
    }

    handleFileInput(event: any) {
        var files = (event.target.files) as FileList;
        if (files.length > 0) {
            var file = files.item(0);
            if (file != null) {
                this.fileToUpload = file;
                this.headShotModel.name = file.name;
                this.headShotModel.size = file.size;
                this.fileReader.readAsDataURL(this.fileToUpload);
            }

            //this.imageChangedEvent = event;
            this.showImgeCropper = true;
        }
    }

    imageCropped(event: ImageCroppedEvent) {
        this.headShotModel.dataUrl = event.base64;
    }

    imageLoaded() {
        // show cropper
    }

    loadImageFailed() {
        // show message
    }

    //load() {
    //    this.profileService.GetHeadShotDetails().subscribe(response => {
    //        if (response != null) {
    //            if (response.dataUrl == null || response.dataUrl == "") {
    //                response.dataUrl = response.imageUrl;                  
    //            }

    //            this.headShotModel = _.cloneDeep(response);
    //            //this.showImgeCropper = true;
    //        }
    //        else {
    //            console.info("Got empty result: ProfileHeadShotComponent.load()");
    //        }
    //    });
    //}

    uploadImage() {
        //const formData: FormData = new FormData
        //formData.append('Image', this.headShotModel.fileToUpload, this.headShotModel.fileToUpload.name);
        //formData.append('ImageCaption', this.headShotModel.caption);

        //this.http.request(new HttpRequest('POST', "api/Profile/Image/UploadImage", formData, { reportProgress: true })).subscribe((event: any) => {


        //    if (event.type === HttpEventType.UploadProgress)
        //        this.progress = Math.round(100 * event.loaded / event.total);
        //    else if (event.type === HttpEventType.Response)
        //        this.message = event.body.toString();
        //});

        this.headShotModel.imageType = 1;
        this.profileService.UploadHeadShotImage(this.headShotModel).subscribe((event: any) => {
            if (event.type === HttpEventType.UploadProgress)
                this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response) {
                //this.message = event.body.toString();
                this.toastr.success(event.body.toString());
            }
        });
    }

    rotate(isClockwise: boolean) {
        var sup = this;  
        this.isRightRotating = !isClockwise;
        this.isLeftRotating = isClockwise;
        if (!this.cropperBase64) return;        
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
        //image.crossOrigin = "Anonymous";
        image.src = base64data;
    }

}
