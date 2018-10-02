import { Component } from "@angular/core";
import { SearchService } from "../../search/search.Service";
//import { ProfileIndexAbstract } from "../../comBase/profileIndexAbstract";
import * as _ from "lodash";
import { ActivatedRoute } from "@angular/router";
@Component({
    selector: "search-index",
    templateUrl: "././index.component.html",
    styleUrls: ['././index.component.css']
})


export class SearchIndex {
    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly searchService: SearchService) {  }

    ngOnInit() {
       //this.activatedRoute.params.subscribe(param => this.profileService.ProfileUrl = param['profileUrl']);
       
    }

    //loadHeaderData() {
    //    this.profileService.GetUserProfileHeader().subscribe(response => {
    //        if (response != null) {
    //            this.ProfileHeader = _.cloneDeep(response);
    //            this.AboutMe = _.cloneDeep(response.about);
    //            this.SelectedGroups = _.cloneDeep(response.jobGroups);
    //            this.FilterData(response.jobGroups);
    //            this.LoadSection();

    //        }
    //        else {
    //            console.info("Got empty result: ProfileIndex.loadHeaderData()");
    //        }
    //    });
    //}
}

