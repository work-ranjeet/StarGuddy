import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { map } from 'rxjs/operators';
import { Observable } from "rxjs";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import IUserCredits = App.Client.Profile.IUserCreditModel;
import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;
import IDancingModel = App.Client.Profile.IDancingModel;
import IDancingStyle = App.Client.Profile.IDancingStyleModel;
import IActingDetailModel = App.Client.Profile.IUserActingModel;
import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IUserNameModel = App.Client.Profile.IUserNameModel;
import IUserDetailModel = App.Client.Profile.IUserDetailModel;
import IAddress = App.Client.Profile.IAddressDto;
import IHeadShot = App.Client.Profile.IImageModel;
import IUserCreditRequest = App.Client.Profile.IUserCreditRequest;
import IUserImageModel = App.Client.Profile.IUserImageModel;
import IUserImageDeleteModel = App.Client.Profile.IUserImageDeleteModel;

@Injectable()
export class ProfileEditService {

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService, private http: HttpClient,
        private readonly dataConverter: DataConverter) {
    }

    //-------------Physical Appearance-------------------------------//
    GetUserPhysicalAppreance(): Observable<IPhysicalAppearance> {
        return this.baseService.HttpService.getData<IPhysicalAppearance>("Profile/Operations/PhysicalApperance").pipe(
            map(result => {
                return result;
            },
                (err: any) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    SaveUserPhysicalAppreance(physicalAppearance: IPhysicalAppearance): Observable<boolean> {
        return this.baseService.HttpService.postData<IPhysicalAppearance>("Profile/Operations/SavePhysicalApperance", physicalAppearance).pipe(
            map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                }));
    }

    // --------------- User Credits ------------------------//
    GetUserCredits(): Observable<IUserCredits[]> {
        return this.baseService.HttpService.getData<IUserCredits[]>("Profile/Operations/Credit").pipe(
            map((result: IUserCredits[]) => {
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
    SaveUserCredits(credits: IUserCredits[]): Observable<boolean> {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Credit", credits).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                }));
    }
    DeleteUserCredits(id: string): Observable<boolean> {
        //let httpParams = new HttpParams();
        // httpParams.append("Id", id);

        return this.baseService.HttpService.deleteData<boolean>("Profile/Operations/Credit", new HttpParams().append("userId", id)).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                }));
    }

    // --------------- User Dancing ------------------------//
    GetUserDanceDetail(): Observable<IDancingModel> {
        return this.baseService.HttpService.getData<IDancingModel>("Profile/Operations/Dancing").pipe(
            map((result: IDancingModel) => {
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
    SaveUserDancingChanges(dancingModel: IDancingModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Dancing", dancingModel).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                }));
    }

    // --------------- User Acting ------------------------//
    GetUserActingDetail(): Observable<IActingDetailModel> {
        return this.baseService.HttpService.getData<IActingDetailModel>("Profile/Operations/Acting").pipe(
            map((result: IActingDetailModel) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetUserActingDetail: Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetUserActingDetail: Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    SaveUserActingDetails(reqPayLoad: IActingDetailModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Acting", reqPayLoad).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("SaveUserActingDetails: Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("SaveUserActingDetails: Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    // --------------- User Modeling ------------------------//
    GetUserModelingDetail(): Observable<IModelingDetailModel> {
        return this.baseService.HttpService.getData<IModelingDetailModel>("Profile/Operations/Modeling").pipe(
            map((result: IModelingDetailModel) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetUserModelingDetail: Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetUserModelingDetail: Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    SaveUserModelingDetails(reqPayLoad: IModelingDetailModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Modeling", reqPayLoad).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("SaveUserModelingDetails: Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("SaveUserModelingDetails: Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    // --------------- User Interests ------------------------//
    GetUserInterestDetail(): Observable<IJobGroupModel[]> {
        return this.baseService.HttpService.getData<IJobGroupModel[]>("Profile/Operations/Interests").pipe(
            map((result: IJobGroupModel[]) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetUserInterestDetail: Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetUserInterestDetail: Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    SaveUserInterestDetail(requestData: IJobGroupModel[]): Observable<boolean> {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Interests", requestData).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("SaveUserInterestDetail:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("SaveUserInterestDetail:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    // Name
    GetUserNameDetail(): Observable<IUserNameModel> {
        return this.baseService.HttpService.getData<IUserNameModel>("Profile/Operations/name").pipe(
            map((result: IUserNameModel) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetUserNameDetail:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetUserNameDetail:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    SaveUserNameDetail(payLoad: IUserNameModel) {
        return this.baseService.HttpService.patchData<boolean>("Profile/Operations/name", payLoad).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("SaveUserNameDetail:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("SaveUserNameDetail:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    // Profile Header
    GetUserProfileHeader(): Observable<IProfileHeader> {
        return this.baseService.HttpService.getData<IProfileHeader>("Profile/Operations/header").pipe(
            map((result: IProfileHeader) => {
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


    // Intro
    GetUserDetail(): Observable<IUserDetailModel> {
        return this.baseService.HttpService.getData<IUserDetailModel>("Profile/Operations/detail").pipe(
            map((result: IUserDetailModel) => {
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

    SaveUserIntro(payLoad: IUserDetailModel) {
        return this.baseService.HttpService.patchData<boolean>("Profile/Operations/intro", payLoad).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("SaveUserIntro:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("SaveUserIntro:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    //Address
    GetUserCurrentAddress(): Observable<IAddress> {
        return this.baseService.HttpService.getData<IAddress>("Profile/Operations/address").pipe(
            map((result: any) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetUserCurrentAddress:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetUserCurrentAddress:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    UpdateUserAddress(payLoad: IAddress) {
        return this.baseService.HttpService.patchData<boolean>("Profile/Operations/address", payLoad).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("UpdateUserAddress:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("UpdateUserAddress:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }

    // Image upload
    GetHeadShotDetails(): Observable<IHeadShot> {
        return this.baseService.HttpService.getData<IHeadShot>("Profile/Image/headshot").pipe(
            map((result: any) => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("GetHeadShotDetails:Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("GetHeadShotDetails:Server-side error occurred. Error:" + err.message);
                    }
                })
        );
    }
    UploadHeadShotImage(headShot: IHeadShot): Observable<any> {
        return this.baseService.HttpService.postDataWithProgress<any>("Profile/Image/headshot", headShot).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("UploadHeadShotImage. Error:" + err.message);
                    } else {
                        console.log("UploadHeadShotImage. Error:" + err.message);
                    }
                })
        );
    }

    //UploadHeadShotImage(caption: string, fileToUpload: File) {
    //    const formData: FormData = new FormData
    //    formData.append('Image', fileToUpload, fileToUpload.name);
    //    formData.append('ImageCaption', caption);
    //    return this.baseService.HttpService.postData<boolean>("Profile/Image/UploadImage", formData)
    //        .map(
    //            (result: any) => {
    //                return result;
    //            },
    //            (err: HttpErrorResponse) => {
    //                if (err.error instanceof Error) {
    //                    console.log("Client-side error occurred. Error:" + err.message);
    //                } else {
    //                    console.log("Server-side error occurred. Error:" + err.message);
    //                }
    //            });
    //}



    /// ------------------------------ Images ---------------------------
    GetAllImages(): Observable<Array<IUserImageModel>> {
        return this.baseService.HttpService.getData<Array<IUserImageModel>>("Profile/Image/all");
    }

    UploadImage(image: IUserImageModel): Observable<any> {
        return this.baseService.HttpService.postDataWithProgress<any>("Profile/Image/uploadGallery", image).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("UploadImage. Error:" + err.message);
                    } else {
                        console.log("UploadImage. Error:" + err.message);
                    }
                })
        );
    }

    DeleteImage(imageId: string): Observable<any> {
        return this.baseService.HttpService.postData<any>("Profile/Image/delete", { id: imageId } as IUserImageDeleteModel).pipe(
            map(result => {
                return result;
            },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("DeleteImage. Error:" + err.message);
                    } else {
                        console.log("DeleteImage. Error:" + err.message);
                    }
                })
        );
    }
}
