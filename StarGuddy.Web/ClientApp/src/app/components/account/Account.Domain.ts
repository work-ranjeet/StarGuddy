namespace App.Client.Account {
    export interface IJwtPacket {
        UserId: string;
        Token: string;
        FirstName: string;
        UserName: string;
        Email: string;
    }

    export interface ILoginData {
        userName: string;
        password: string;
        rememberMe: boolean;
    }

    export interface IChangePassword {
        userName: string;
        password: string;
        newPassword: string;
        cnfPassword: string;
    }

    export interface IApplicationUser {
        userId: string;
        userName: string;
        email: string;
        firstName: string;
        lastName: string;
        password: string;
        cnfPassword: string;
        gender: string;
        isCastingProfessional: boolean;
        isEmailVerified: boolean;
        orgName: string;
        orgWebsite: string;
        designation: string;
    }

    export interface IKeyValuePair {
        key: string;
        value: string;
    }

    export interface IEmailVerifyRequest {
        userId: string;
    }
}
