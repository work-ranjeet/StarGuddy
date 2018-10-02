import { Injectable } from "@angular/core";
//import { ToastsManager } from "ng2-toastr";

@Injectable()
export class ToastrService {

   // constructor(private toastr: ToastsManager) {}

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
       // this.toastr.info(message, title);
    }

    showCustom() {
       // this.toastr.custom('<span style="color: red">Message in red.</span>', null, { enableHTML: true });
    }

}
