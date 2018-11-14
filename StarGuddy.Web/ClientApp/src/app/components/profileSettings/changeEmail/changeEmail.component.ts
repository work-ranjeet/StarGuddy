import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;
import { FormBuilder, Validators, FormGroup, FormControl } from "@angular/forms";

@Component({
    selector: "account-management-change-email",
    templateUrl: "././changeEmail.component.html",
    styleUrls: ['././changeEmail.component.css']
})

export class ChangeEmailComponent {
   
    public returnUrl: string;
    public changeEmailForm: FormGroup;
    public userEmail: IUserEmail = {} as IUserEmail;

    constructor(
        private _formBuilder: FormBuilder, 
        private router: Router,
        private authenticateRoute: ActivatedRoute,
        private profileSettingService: ProfileSettingsService,
        private dataValidator: DataValidator) {  }


    ngOnInit() {
        this.initForm();
    }

    initForm() {
        this.changeEmailForm = this._formBuilder.group({
            email: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
            ]))
        });
    }

    updateEmail() {
        if (this.dataValidator.IsValidObject(this.userEmail)) {
            this.profileSettingService.updateEmail(this.userEmail).subscribe(
                result => {

                },
                error => {
                    console.error(error);
                });
        }
    }

    public validation_messages = {
        'email': [
            { type: 'required', message: 'Email is required' },
            { type: 'pattern', message: 'Enter a valid email' }
        ]
    }
}
