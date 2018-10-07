import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import ISectionVesbility = App.Client.PublicProfile.ISectionVesbility;
import * as _ from "lodash";

export class ProfileIndexAbstract {
    private _jobGroupName: string = "";
    private _aboutMe: string = "";
    private _selectedGroups: Array<IJobGroupModel> = [];
    private _selectedGroupsName: Array<string> = [];
    private _profileHeader: IProfileHeader = {} as IProfileHeader;
    private _setionVisbility: ISectionVesbility = {} as ISectionVesbility;


    get GroupNames(): string { return this._jobGroupName; }
    get SelectedGroups(): Array<IJobGroupModel> { return this._selectedGroups; }
    set SelectedGroups(selectedGroups: Array<IJobGroupModel>) {
        this._selectedGroups = selectedGroups;
        this._selectedGroups.forEach(x => this._selectedGroupsName.push(x.name));
        this._jobGroupName = this._selectedGroupsName.join(", ");
    }

    get AboutMe(): string { return this._aboutMe; }
    set AboutMe(aboutMe: string) {
        if (aboutMe == undefined || aboutMe == null || aboutMe == "") {
            aboutMe = "A brief introduction of who you are.";
        }
        this._aboutMe = aboutMe;
    }

    get ProfileHeader(): IProfileHeader { return this._profileHeader; }
    set ProfileHeader(profileHeader: IProfileHeader) {
        if (profileHeader.displayName == undefined || profileHeader.displayName == null || profileHeader.displayName == "") {
            profileHeader.displayName = profileHeader.firstName + " " + profileHeader.lastName;
        }

        this._profileHeader = profileHeader;
    }

    get SetionVisbility(): ISectionVesbility { return this._setionVisbility; }
    set SetionVisbility(section: ISectionVesbility) { this._setionVisbility = section; }  

    ChangeMenuSelection(menuCode: string) {
        let el = document.getElementById(menuCode);
        if (el != null)
            el.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
    }

    SetSectionCenter(menuCode: string) {
        let el = document.getElementById(menuCode);
        if (el != null)
            el.scrollIntoView({ behavior: "smooth", block: "nearest", inline: "start" });
    }

    LoadSection() {
        //Acting  1001, Modeling  1002, Extras  1003, Presenter  1004, Musician  1005, Photography 1006, TV & Reality 1007, Dancing 1008, Film & Stage Crew 1009
        //Hair, Makeup, & Styling 1010, Survival Jobs 1011

        this.SetionVisbility.showActing = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1001; }) > -1;
        this.SetionVisbility.showModeling = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1002; }) > -1;
        this.SetionVisbility.showExtras = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1003; }) > -1;
        this.SetionVisbility.showPresenter = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1004; }) > -1;
        this.SetionVisbility.showMusician = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1005; }) > -1;
        this.SetionVisbility.showPhotography = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1006; }) > -1;
        this.SetionVisbility.showTVReality = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1007; }) > -1;
        this.SetionVisbility.showDancing = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1008; }) > -1;
        this.SetionVisbility.showFilmStageCrew = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1009; }) > -1;
        this.SetionVisbility.showHairMakeupStyling = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1010; }) > -1;
        this.SetionVisbility.showSurvivalJobs = _.findIndex(this.SelectedGroups, function (o) { return o.code == 1011; }) > -1;
    }
}
