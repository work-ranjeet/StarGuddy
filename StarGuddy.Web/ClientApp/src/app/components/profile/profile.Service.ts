import { HttpErrorResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Observable } from "rxjs/Observable";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import IUserProfile = App.Client.PublicProfile.IUserProfile;
import IUserModelingModel = App.Client.Profile.IUserModelingModel;
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IUserCredits = App.Client.Profile.IUserCreditModel;
import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;
import IDancingModel = App.Client.Profile.IDancingModel;
import IActingDetailModel = App.Client.Profile.IUserActingModel;

@Injectable()
export class ProfileService {
    private _profileUrl: string = "";
    private profileDetailData = new BehaviorSubject<IUserProfile>({} as IUserProfile);
    public get PublicProfileData(): Observable<IUserProfile> { return this.profileDetailData.asObservable(); }
    public SetPublicProfileData(data: IUserProfile) { this.profileDetailData.next(data); }

    public get ProfileUrl(): string { return this._profileUrl; }
    public set ProfileUrl(profileUrl: string) { this._profileUrl = profileUrl; }

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly dataConverter: DataConverter) { }

    //-------------Profile details-------------------------------//
    GetProfileDetails(): Observable<IUserProfile> {
        return this.baseService.HttpService.getData<IUserProfile>("Profile/" + this.ProfileUrl)
            .map(
                (result: IUserProfile) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    // Profile Header
    GetUserProfileHeader(): Observable<IProfileHeader> {
        return this.baseService.HttpService.getData<IProfileHeader>("/Profile/" + this.ProfileUrl + "/header")
            .map(
                (result: IProfileHeader) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    GetUserPhysicalAppreance(): Observable<IPhysicalAppearance> {
        return this.baseService.HttpService.getData<IPhysicalAppearance>("Profile/" + this.ProfileUrl + "/PhysicalApperance")
            .map(
                (result: IPhysicalAppearance) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    GetUserCredits(): Observable<IUserCredits[]> {
        return this.baseService.HttpService.getData<IUserCredits[]>("Profile/" + this.ProfileUrl + "/Credit")
            .map(
                (result: IUserCredits[]) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    GetUserDanceDetail(): Observable<IDancingModel> {
        return this.baseService.HttpService.getData<IDancingModel>("Profile/" + this.ProfileUrl + "/Dancing")
            .map(
                (result: IDancingModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    GetUserActingDetail(): Observable<IActingDetailModel> {
        return this.baseService.HttpService.getData<IActingDetailModel>("Profile/" + this.ProfileUrl + "/Acting")
            .map(
                (result: IActingDetailModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    GetUserModelingDetail(): Observable<IUserModelingModel> {
        return this.baseService.HttpService.getData<IUserModelingModel>("Profile/" + this.ProfileUrl + "/Modeling")
            .map(
                (result: IUserModelingModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }
}
