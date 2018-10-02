namespace App.Client.PublicProfile {

    import Profile = App.Client.Profile;

    export interface IUserProfile {
        physicalAppearance: Profile.IPhysicalAppearanceModal;
        userCredits: Array<Profile.IUserCreditModel>;
        dancing: Profile.IDancingModel;
        acting: Profile.IUserActingModel;
        modeling: Profile.IUserModelingModel;
    }

    export interface IProfileHeader {
        id: string;
        firstName: string;
        lastName: string;
        displayName: string;
        about: string;
        cityOrTown: string;
        stateOrProvince: string;
        country: string;
        phoneNumber: string;
        email: string;
        imageUrl: string;
        dataUrl: string;
        jobGroups: Profile.IJobGroupModel[];
    }

    export interface ISectionVesbility {
        showActing: boolean;
        showModeling: boolean;
        showExtras: boolean;
        showPresenter: boolean;
        showMusician: boolean;
        showPhotography: boolean;
        showTVReality: boolean;
        showDancing: boolean;
        showFilmStageCrew: boolean;
        showHairMakeupStyling: boolean;
        showSurvivalJobs: boolean;
    }
}