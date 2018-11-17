import { Component } from "@angular/core";
import { DataValidator } from "../../../Helper/DataValidator";
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ProfileSettingsService } from "../../profileSettings/profileSettings.Service";

@Component({
    selector: "account-management-change-phone-number",
    templateUrl: "././changePhoneNumber.component.html",
    styleUrls: ['././changePhoneNumber.component.css']
})

export class ChangePhoneNumberComponent {

    public mobNumber: string;
    public changePhoneForm: FormGroup;

    constructor(
        private readonly _formBuilder: FormBuilder,
        private readonly service: ProfileSettingsService) { }


    ngOnInit() {
        this.initForm();
    }

    initForm() {
        this.changePhoneForm = this._formBuilder.group(
            {
                mobileNumber: new FormControl('', Validators.compose([
                    Validators.minLength(10),
                    Validators.required
                ]))
            });
    }

    public validation_messages = {
        'mobile': [
            { type: 'required', message: 'Mobile number is required' }
        ]
    }
}
