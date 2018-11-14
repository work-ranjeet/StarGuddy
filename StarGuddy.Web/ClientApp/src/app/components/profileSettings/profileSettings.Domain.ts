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
}
