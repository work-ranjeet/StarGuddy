import { HttpErrorResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import "rxjs/add/operator/map";
import { Observable } from "rxjs/Observable";
import { DataConverter } from "../../Helper/DataConverter";
import { BaseService } from "../../Services/BaseService";
import ITalentGroupModel = App.Client.Search.ITalentGroupModel;

@Injectable()
export class SearchService {


    constructor(@Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) { }


    //load groups
    GetTalentGroupDetail(): Observable<Array<ITalentGroupModel>> {
        return this.baseService.HttpService.getData<Array<ITalentGroupModel>>("Search/TalentGroups")
            .map(
                (result: Array<ITalentGroupModel>) => {
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
