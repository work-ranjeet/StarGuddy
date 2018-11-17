namespace App.Client.Profile.Setting {

    export interface IUserEmail {
        userId: string;
        email: string;
    }

    export interface IChangePassword {
        userId: string;
        oldPassword: string;
        newPassword: string;
        confirmPassword: string;
    }

    export interface IVisibilityGroupDto {
        id: string;
        groupName: string;
        groupOwnerId: string;
    }

    export interface IUserSettingDto {
        id: string;
        userId: string;
        visibilityGroupId: string;
        visibilityGroups: Array<IVisibilityGroupDto>;
        isProfilePhotoVisibile: boolean;
        isProfileCommentAllowed: boolean;
        isMobileVisible: boolean;
        isEmailVisible: boolean;
        profileUrl: string;
        isProfileDisabled: boolean;
    }
}
