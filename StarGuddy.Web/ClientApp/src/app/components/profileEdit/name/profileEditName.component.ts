import { Component } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IUserNameModel = App.Client.Profile.IUserNameModel;
import * as _ from 'lodash';
import { Router } from '@angular/router';
import { MatRadioGroup,  MatRadioButton, MatRadioChange } from "@angular/material";
import { FormBuilder, Validators, FormGroup, FormControl} from "@angular/forms";
import { ToastrService } from '../../../Services/ToastrService';



/** @title Simple form field */
@Component({
    selector: "profile-edit-name",
    templateUrl: "././profileEditName.component.html",
    styleUrls: ['././profileEditName.component.css']
})
export class ProfileEditNameComponent {

    public fullName: string = "";
    public shortName: string = "";
    public userNameModel: IUserNameModel = {} as IUserNameModel;
    public frmEditName: FormGroup;

    constructor(
        private _formBuilder: FormBuilder,
        private readonly router: Router,
        private toastr: ToastrService,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.frmEditName = this._formBuilder.group({
            firstName: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('[a-zA-Z][a-zA-Z]+')
            ])),
            lastName: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('[a-zA-Z][a-zA-Z]+')
            ])),
            orgName: new FormControl('')
        });

        this.load();
    }

    load() {
        this.profileService.GetUserNameDetail().subscribe(response => {
            if (response != null) {
                if (response.lastName == undefined || response.lastName == null) {
                    response.lastName = "";
                }

                this.userNameModel = _.cloneDeep(response);
                this.fullName = response.firstName + " " + response.lastName;
                this.shortName = response.firstName + " " + (response.lastName != "" ? response.lastName.slice(0, 1) : "");
            }
            else {
                this.toastr.info("Got empty result");
            }
        });
    }

    save() {
        this.profileService.SaveUserNameDetail(this.userNameModel).subscribe(response => {
            if (response != null && response) {
                this.toastr.success("Updated successfully");
                this.router.navigate(["/profile"]);
            }
            else {
                this.toastr.warning("Ops! There is some issue...");
            }
        });
    }


    firstNameChange(inputVal: string) {
        this.fullName = inputVal + " " + this.userNameModel.lastName;
        this.shortName = inputVal + " " + (this.userNameModel.lastName != "" ? this.userNameModel.lastName.slice(0, 1) : "");
    }

    lastNameChange(inputVal: string) {
        this.fullName = this.userNameModel.firstName + " " + inputVal;
        this.shortName = this.userNameModel.firstName + " " + (inputVal != "" ? inputVal.slice(0, 1) : "");
    }

    radioChange(event: MatRadioChange) {
        this.userNameModel.displayName = event.value;
    }

    public validation_messages = {
        'name': [
            { type: 'required', message: 'Email is required' },
            { type: 'pattern', message: 'Enter a valid email' }
        ],
        'password': [
            { type: 'required', message: 'Password is required' }
        ]
    }
}
