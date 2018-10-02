import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import ISectionVesbility = App.Client.PublicProfile.ISectionVesbility;
import * as _ from "lodash";

export class ProfileIndexAbstract {
    private _jobGroupName: string = "";
    private _aboutMe: string = "";
    private _selectedGroups: Array<IJobGroupModel> = [];
    private _jobGroupNameArray: Array<string> = [];
    private _profileHeader: IProfileHeader = {} as IProfileHeader;
    private _setionVisbility: ISectionVesbility = {} as ISectionVesbility;

    
    get GroupNames(): string { return this._jobGroupName; }
    set GroupNames(jobGroupNames: string) { this._jobGroupName = jobGroupNames; }
    
    get AboutMe(): string { return this._aboutMe; } 
    set AboutMe(aboutMe: string) { this._aboutMe = aboutMe; }
    
    //get GroupNameArray(): Array<string> { return this._jobGroupNameArray; }
    //set GroupNameArray(groupName: Array<string>) { this._jobGroupNameArray = groupName; }
   
    get ProfileHeader(): IProfileHeader { return this._profileHeader; }
    set ProfileHeader(profileHeader: IProfileHeader) { this._profileHeader = profileHeader; }
    
    get SetionVisbility(): ISectionVesbility { return this._setionVisbility; }
    set SetionVisbility(section: ISectionVesbility) { this._setionVisbility = section; }
  
    get SelectedGroups(): Array<IJobGroupModel> { return this._selectedGroups; }
    set SelectedGroups(selectedGroups: Array<IJobGroupModel>) { this._selectedGroups = selectedGroups; }


    FilterData(jobGroups: Array<IJobGroupModel>) {
        if (this.ProfileHeader.displayName == "" || this.ProfileHeader.displayName == undefined) {
            this.ProfileHeader.displayName = this.ProfileHeader.firstName + " " + this.ProfileHeader.lastName;
        }

        if (this.AboutMe == undefined || this.AboutMe == "") {
            this.AboutMe = "A brief introduction of who you are.";
        }

        jobGroups.forEach(x => this._jobGroupNameArray.push(x.name));
        this.GroupNames = this._jobGroupNameArray.join(", ");
    }

    ChangeMenuSelection(menuCode: string) {
        let el = document.getElementById(menuCode);
        if (el != null)
            el.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
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
