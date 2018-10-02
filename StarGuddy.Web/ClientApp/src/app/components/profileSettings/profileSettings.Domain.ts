namespace App.Client.Profile.Setting {

    export interface IUserEmail {
        UserId: string;
        Email: string;
    }

    export interface IChangePassword {
        UserId: string;
        OldPassword: string;
        NewPassword: string;
        ConfirmPassword: string;
    }
}