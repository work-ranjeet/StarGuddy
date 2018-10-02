
interface StringConstructor {
    Empty: string;
    IsNullOrEmpty: (val: any) => boolean;
    IsNotNullOrEmpty: (val: any) => boolean;
}


String.Empty = "";

String.IsNullOrEmpty = function (val: any): boolean {
    return (val === undefined || val === null || val.trim() === '');
};

String.IsNotNullOrEmpty = function (val: any): boolean {
    return (val != undefined && val != null && val.trim() != '');
};
