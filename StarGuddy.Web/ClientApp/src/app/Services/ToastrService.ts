import { Injectable } from "@angular/core";
import { ToastsManager } from "ng5-toastr";

@Injectable()
export class ToastrService {

    public options: any;

    constructor(private toastr: ToastsManager) {
        this.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "0",
            "hideDuration": "0",
            "timeOut": "50000",
            "extendedTimeOut": "3000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    }

    ngOnInit() {
        
    }

    public success(message: string, title?: string) {
        this.toastr.success(message, title, this.options);
    }

    public error(message: string, title?: string) {
        this.toastr.error(message, title, this.options);
    }

    public warning(message: string, title?: string) {
        this.toastr.warning(message, title, this.options);
    }

    public info(message: string, title?: string) {
        this.toastr.info(message, title, this.options);
    }

    showCustom() {
        this.toastr.custom('<span style="color: red">Message in red.</span>', null, { enableHTML: true });
    }
}
