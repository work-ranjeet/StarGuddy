import { Injectable } from "@angular/core";

@Injectable()
export class DataValidator {

    IsValidObject(result: any): boolean {
        return Object.keys(result).length > 0;
    }
}