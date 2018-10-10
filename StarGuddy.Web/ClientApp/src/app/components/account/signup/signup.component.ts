import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { MatCard } from "@angular/material";
import { Router } from "@angular/router";
import { DataValidator } from "../../../Helper/DataValidator";
import { ToastrService } from "../../../Services/ToastrService";
import { AccountService } from "../Account.Service";
import IApplicationUser = App.Client.Account.IApplicationUser;
import IKeyValuePair = App.Client.Account.IKeyValuePair;


/**
 * @title Stepper with editable steps
 */
@Component({
    selector: 'signup',
    templateUrl: '././signup.component.html',
    styleUrls: ['././signup.component.css']
})
export class SignUpComponent {
    public accountDetailsForm: FormGroup;
    public profileDetailForm: FormGroup;
    public orgDetailForm: FormGroup;
    public applicationUser: IApplicationUser;
    public genders: Array<IKeyValuePair> = [];
    public signupTypes: Array<IKeyValuePair> = [];
    public showSpinner: boolean = false;
    public signTypeSelected: string;
    public signup_validation_messages: any;

    constructor(private _formBuilder: FormBuilder, public router: Router, private readonly accountService: AccountService, private readonly dataValidator: DataValidator,
        private toastr: ToastrService) {
        this.router = router;
        this.accountService = accountService;
        this.dataValidator = dataValidator;
        this.applicationUser = { gender: 'M', isCastingProfessional: true } as IApplicationUser;
    }

    ngOnInit() {
        this.initFormData();
        this.initLoginForm();
    }

    initLoginForm() {
        this.accountDetailsForm = this._formBuilder.group(
            {
                email: new FormControl('', Validators.compose([
                    Validators.required,
                    Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
                ])),
                password: new FormControl('', Validators.compose([
                    Validators.minLength(5),
                    Validators.required
                    // Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$')
                ])),
                cnfPassword: new FormControl('', Validators.required)
            });

        this.profileDetailForm = this._formBuilder.group({
            firstName: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('[a-zA-Z][a-zA-Z]+')
            ])),
            lastName: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('[a-zA-Z][a-zA-Z]+')
            ])),
            gender: new FormControl('', [Validators.required])
        });

        this.orgDetailForm = this._formBuilder.group({
            signupType: new FormControl('', [Validators.required]),
            orgName: new FormControl('', Validators.compose([Validators.pattern('[a-zA-Z][a-zA-Z]+')])),
            orgWebsite: new FormControl(''),
            designation: new FormControl('')
            //orgWebsite: new FormControl('', Validators.compose([Validators.pattern('/(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?/')]))
        });
    }

    initFormData() {
        this.genders = [
            { key: "M", value: "Male" },
            { key: "F", value: "Female" },
            { key: "O", value: "Others" }
        ];

        this.signupTypes = [
            { key: "0", value: "Find Work" },
            { key: "1", value: "Find Talent" }
        ];

        this.signup_validation_messages = {
            'email': [
                { type: 'required', message: 'Email is required' },
                { type: 'pattern', message: 'Enter a valid email' }
            ],
            'password': [
                { type: 'required', message: 'Password is required' }
            ],
            'cnfPassword': [
                { type: 'required', message: 'Confirm password is required' },
                { type: 'areEqual', message: 'Password mismatch' }
            ],
            'name': [
                { type: 'required', message: 'Name is required' },
                { type: 'pattern', message: 'Only alphabets allowed' }
            ],
            'orgName': [
                { type: 'pattern', message: 'Only alphabets allowed' }
            ],
            'orgWebsite': [
                { type: 'pattern', message: 'Invalid web url.' }
            ]
        }
    }

    validatePassword() {
        if (this.applicationUser.password != this.applicationUser.cnfPassword) {
            this.accountDetailsForm.controls['cnfPassword'].setErrors({ 'areEqual': true });
            this.accountDetailsForm.controls['cnfPassword'].markAsDirty();
        }
    }

    save() {
        try {
            this.showSpinner = true;
            this.applicationUser.isCastingProfessional = this.signTypeSelected === "1";
            if (this.dataValidator.IsValidObject(this.applicationUser)) {
                this.accountService.signup(this.applicationUser).subscribe(
                    result => {
                        this.showSpinner = false;
                        if (result != undefined) {
                            this.toastr.info(result);
                            //this.router.navigate(["acc-cnf-email-sent"]);
                            this.router.navigate(["/profile"]);
                        }
                    },
                    (error) => {
                        this.showSpinner = false;
                        this.toastr.error(error.message);
                        this.router.navigate(["error"]);
                    });
            }
        } catch (e) {
            this.showSpinner = false;
        }
    }
}
