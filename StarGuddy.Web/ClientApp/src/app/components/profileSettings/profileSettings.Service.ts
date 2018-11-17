//import { Observable } from "rxjs/Observable";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from "rxjs";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;
import IUserSettingDto = App.Client.Profile.Setting.IUserSettingDto;
import { HttpErrorResponse } from "@angular/common/http";


@Injectable()
export class ProfileSettingsService {

    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor(@Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) { }


    UpdateEmail(userEmail: IUserEmail) {
        return this.baseService.HttpService.post("Profile/Setting/UpdateEmail", userEmail);
    }

    GetUserSettings(): Observable<IUserSettingDto> {
        return this.baseService.HttpService.getData<IUserSettingDto>("Profile/Setting").pipe(
            map((result: IUserSettingDto) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

}
