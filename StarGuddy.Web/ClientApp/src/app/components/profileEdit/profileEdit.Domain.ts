namespace App.Client.Profile {


    export interface IPhysicalAppearanceModal {
        bodyType: string;
        chest: string;
        eyeColor: string;
        hairColor: string;
        hairLength: string;
        hairType: string;
        skinColor: string;
        height: string;
        weight: string;
        west: string;
        ethnicity: string;
    }

    export interface IUserCreditModel {
        id: string;
        action: string;
        workYear: number;
        workPlace: string;
        workDetail: string;
    }

    export interface IUserCreditRequest {
        userCreditList:Array<IUserCreditModel>;
    }

    export interface IDancingStyleModel {
        id: string;
        selectedValue: number;
        value: number;
        name: string;
    }

    export interface IDancingModel {
        id: string;
        userId: string;
        danceAbilities: number;
        danceAbilitiesText: string;
        choreographyAbilities: number;
        choreographyAbilitiesText: string;
        agentNeed: number;
        experience: string;
        isAttendedSchool: boolean;
        isAgent: boolean;
        hasDanceStyle: boolean;
        dnacingStyles: IDancingStyleModel[];
    }

    export interface IAccents {
        id: number;
        name: string;
        code: string;
        languageCode: string;
        selectedAccent: string;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface ILanguage {
        id: number;
        name: string;
        code: string;
        selectedLanguageCode: string;
        countryCode: string;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface IAuditionsAndJobsGroup {
        id: number;
        name: string;
        code: number;
        selectedCode: number;
        detail: string;
        displayOrder: number;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface IUserActingModel {
        id: string;
        userId: string;
        actingExperianceCode: number;
        actingExperiance: string;
        agentNeedCode: number;
        experiance: string;
        languages: ILanguage[];
        accents: IAccents[];
        auditionsAndJobsGroup: IAuditionsAndJobsGroup[];
    }

    export interface IUserModelingModel {
        id: string;
        expCode: number;
        expText: string;
        agentNeedCode: number;
        webSite: string;
        experiance: string;
        modelingRoles: IAuditionsAndJobsGroup[];
    }

    export interface IJobGroupModel {
        id: number;
        name: string;
        code: number;
        selectedCode: number;
        detail: string;
        displayOrder: number;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface IUserNameModel {
        Id: string;
        firstName: string;
        lastName: string;
        displayName: string;
        orgName: string;
    }

    export interface IUserDetailModel {
        userId: string;
        about: string;
        profileAddress: string;
        age: number;
        bloodGroup: number;
        dateOfBirth: Date;
        disability: string;
        healthInfo: string;
        maritalStatus: number;
        motherTongue: string;
        nickname: string;
        religion: string;
    }

    export interface IAddressDto {
        id: string;
        userId: string;
        appOrHouseName: string;
        cityOrTown: string;
        country: string;
        flat: string;
        landMark: string;
        lineOne: string;
        lineTwo: string;
        stateOrProvince: string;
        zipOrPostalCode: string;
    }

    export interface IImageModel {
        id: string;
        userId: string;
        name: string;
        size: number;
        caption: string;
        imageUrl: string;
        dataUrl: string;
        imageType: number;
    }
}