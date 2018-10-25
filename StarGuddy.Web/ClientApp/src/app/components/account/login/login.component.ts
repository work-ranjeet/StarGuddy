import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataValidator } from "../../../Helper/DataValidator";
import { ToastrService } from "../../../Services/ToastrService";
import { AccountService } from "../Account.Service";
import { MatCard } from "@angular/material";
import ILoginData = App.Client.Account.ILoginData;
import { FormBuilder, Validators, FormGroup, FormControl } from "@angular/forms";


@Component({
    selector: "account-login",
    templateUrl: "././login.component.html",
    styleUrls: ['././login.component.css']
})

export class AccountLoginComponent {
    public loginData: ILoginData;
    public returnUrl: string;
    public showSpinner: boolean = false;
    public loginForm: FormGroup;

    constructor(private _formBuilder: FormBuilder, public router: Router, public authenticateRoute: ActivatedRoute, public accountService: AccountService,
        public dataValidator: DataValidator, private toastr: ToastrService) {
        this.loginData = {} as ILoginData;        
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/profile";
    }

    ngOnInit() {
        this.initLoginForm();
    }

    initLoginForm() {
        this.loginForm = this._formBuilder.group({
            email: new FormControl('', Validators.compose([
                Validators.required,
                Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
            ])),
            password: new FormControl('', Validators.required)
        });
    }

    login() {
        this.showSpinner = true;
        if (this.dataValidator.IsValidObject(this.loginData)) {
            this.accountService.login(this.loginData).subscribe(
                data => {
                    this.showSpinner = false;
                    if (data.isEmailVerified)
                        this.router.navigate([this.returnUrl]);
                    else {
                        this.router.navigate(['acc-cnf-email-sent', "Welcome back! " + data.firstName, data.userId, "login"]);
                    }
                },
                error => {
                    this.showSpinner = false;
                    this.toastr.error(error.error);
                });
        }
    }

    public account_validation_messages = {
        'email': [
            { type: 'required', message: 'Email is required' },
            { type: 'pattern', message: 'Enter a valid email' }
        ],
        'password': [
            { type: 'required', message: 'Password is required' }
        ]
    }
}

