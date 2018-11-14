import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";
import { DataValidator } from "../../../Helper/DataValidator";
import IChangePassword = App.Client.Account.IChangePassword;
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: "account-management-change-password",
    templateUrl: "././changePwd.component.html",
    styleUrls: ['././changePwd.component.css']
})

export class ChangePwdComponent {
    public changePwdForm: FormGroup;
    public changePwd: IChangePassword = {} as IChangePassword;

    constructor(
        private _formBuilder: FormBuilder,
        private router: Router,
        private authRoute: ActivatedRoute,
        private service: ProfileSettingsService,
        private dataValidator: DataValidator) { }

    ngOnInit() {
        this.changePwd = {} as IChangePassword;
        this.initForm();
    }

    initForm() {
        this.changePwdForm = this._formBuilder.group(
            {
                password: new FormControl('', Validators.compose([
                    Validators.minLength(5),
                    Validators.required
                ])),
                newPassword: new FormControl('', Validators.compose([
                    Validators.minLength(5),
                    Validators.required
                ])),
                cnfPassword: new FormControl('', Validators.required)
            });
    }

    validatePassword() {
        if (this.changePwd.newPassword != this.changePwd.cnfPassword) {
            this.changePwdForm.controls['cnfPassword'].setErrors({ 'areEqual': true });
            this.changePwdForm.controls['cnfPassword'].markAsDirty();
        }
    }




    //login() {
    //    if (this.dataValidator.IsValidObject(this.loginData)) {
    //        this.accountService.login(this.loginData).subscribe(
    //            result => {
    //                this.router.navigate([this.returnUrl]);
    //            },
    //            error => {
    //                console.error(error);
    //            });
    //    }
    //}

    public validation_messages = {       
        'password': [
            { type: 'required', message: 'Password is required' }
        ],
        'cnfPassword': [
            { type: 'required', message: 'Confirm password is required' },
            { type: 'areEqual', message: 'Password mismatch' }
        ]
    }
}
