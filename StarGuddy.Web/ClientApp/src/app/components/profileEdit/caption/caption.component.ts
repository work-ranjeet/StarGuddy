import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { ToastrService } from '../../../Services/ToastrService';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserNameModel = App.Client.Profile.IUserNameModel;



/** @title Simple form field */
@Component({
    selector: "profile-edit-caption",
    templateUrl: "././caption.component.html",
    styleUrls: ['././caption.component.css']
})
export class ProfileEditCaptionComponent {

    public caption: string = "";
    public frmEditCaption: FormGroup;

    constructor(
        private _formBuilder: FormBuilder,
        private readonly router: Router,
        private toastr: ToastrService,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.frmEditCaption = this._formBuilder.group({
            photoCaption: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('[a-zA-Z][a-zA-Z]+')
            ]))
        });
    }
    save() {}
    //load() {
    //    this.profileService.GetUserNameDetail().subscribe(response => {
    //        if (response != null) {
    //            this.caption = "";
    //        }
    //        else {
    //            this.toastr.info("Got empty result");
    //        }
    //    });
    //}

    //save() {
    //    this.profileService.SaveUserNameDetail(this.userNameModel).subscribe(response => {
    //        if (response != null && response) {
    //            this.toastr.success("Updated successfully");
    //            this.router.navigate(["/profile"]);
    //        }
    //        else {
    //            this.toastr.warning("Ops! There is some issue...");
    //        }
    //    });
    //}


   

    public validation_messages = {
        'caption': [
            { type: 'required', message: 'Email is required' },
            { type: 'pattern', message: 'Enter a valid email' }
        ]
    }
}
