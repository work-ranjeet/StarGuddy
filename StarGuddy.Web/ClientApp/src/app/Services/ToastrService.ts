import { Injectable } from "@angular/core";
//import { ToastsManager, ToastOptions } from "ng5-toastr";

@Injectable()
export class ToastrService {

    public options: any;

    //constructor(private toastr: ToastsManager) {
       
    //}

    ngOnInit() {
        
    }

    public success(message: string, title?: string) {
        //this.toastr.success(message, title);
    }

    public error(message: string, title?: string) {
        //this.toastr.error(message, title);
    }

    public warning(message: string, title?: string) {
        //this.toastr.warning(message, title);
    }

    public info(message: string, title?: string) {
        //this.toastr.info(message, title);
    }

    showCustom() {
        //this.toastr.custom('<span style="color: red">Message in red.</span>', null, { enableHTML: true });
    }
}

export class ToasterOption //extends ToastOptions
{
    positionClass = "toast-top-center";   
    newestOnTop = true;
    showCloseButton = true;
    showPinButton = true;
}

//this.options = {
//animate = 'flyRight'; 
//    "closeButton": true,
//    "debug": true,
//    "newestOnTop": true,
//    "progressBar": false,
//    "positionClass": "toast-bottom-right",
//    "preventDuplicates": false,
//    "onclick": null,
//    "showDuration": "0",
//    "hideDuration": "0",
//    "timeOut": "50000",
//    "extendedTimeOut": "3000",
//    "showEasing": "swing",
//    "hideEasing": "linear",
//    "showMethod": "fadeIn",
//    "hideMethod": "fadeOut"
//};
