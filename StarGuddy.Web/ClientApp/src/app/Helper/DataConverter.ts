import { Injectable } from "@angular/core";

@Injectable()
export class DataConverter {
    ConvertToString(value: any): string {
        if (value === null || value === undefined || typeof value === "string")
            return value;

        return value.toString();
    }

    ConvertToBoolean(value: any): boolean {
        if (value === null || value === undefined || typeof value === "boolean")
            return value;

        return value.toString() === "true";
    }

    ConvertToNumber(value: any): number {
        if (value === null || value === undefined || typeof value === "number")
            return value;

        return parseFloat(value.toString());
    }
}