import { Component, ViewContainerRef } from "@angular/core";
import { ToastsManager } from "ng5-toastr";

@Component({
  selector: "app-root",
    templateUrl: "./appIndex.component.html"
})
export class AppIndexComponent {
    title = 'app';
    constructor(public toastr: ToastsManager, vcr: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vcr);
    }
}
