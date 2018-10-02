namespace App.Client.Search {
    export interface ITalentGroupModel {
        id: number;
        name: string;
        code: number;
        selectedCode: number;
        detail: string;
        displayOrder: number;
        imageUrl: string;
        memberCount: number;
    }
}