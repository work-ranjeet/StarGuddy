import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../../profile/profile.Service";
import IActingDetailModel = App.Client.Profile.IUserActingModel;
import { ActingExperiance } from "../../../Enums/enums";

@Component({
    selector: "profile-acting",
    templateUrl: "././acting.component.html",
    styleUrls: ['././acting.component.css']
})


export class ProfileActingComponent {
    private subscription: any;
    public showLanguage: boolean = true;
    public showAccents: boolean = true;
    public showActing: boolean = false;
    public actingDetailModel: IActingDetailModel = {} as IActingDetailModel;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        this.loadActingDetails();
    }

    loadActingDetails() {
        this.profileService.GetUserActingDetail().subscribe(
            response => {
                if (response != null) {
                    this.filterResponse(response);
                    this.actingDetailModel = _.cloneDeep(response);
                }
            },
            err => { this.showActing = false; console.error(err.error) });
    }

    filterResponse(response: IActingDetailModel) {
        if (response.actingExperiance == "") {
            response.actingExperianceCode = 200;
            response.actingExperiance = ActingExperiance[response.actingExperianceCode];
        }
        if (response.languages.length > 0 && response.languages.findIndex(x => x.selectedLanguageCode != "") < 0) {
            this.showLanguage = false;
        }

        if (response.accents.length > 0 && response.accents.findIndex(x => x.selectedAccent != "") < 0) {
            this.showAccents = false;
        }
    }
}
