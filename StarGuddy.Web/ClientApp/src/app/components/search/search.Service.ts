import { HttpErrorResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { map } from 'rxjs/operators';
import { Observable } from "rxjs";
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
        return this.baseService.HttpService.getData<Array<ITalentGroupModel>>("Search/TalentGroups");
    }
}
