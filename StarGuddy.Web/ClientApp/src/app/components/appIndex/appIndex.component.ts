import { Component } from "@angular/core";
//import { ToastsManager } from "ng2-toastr";

@Component({
  selector: "app-root",
    templateUrl: "./appIndex.component.html",
    styleUrls: ["./appIndex.component.css"]
})
export class AppIndexComponent {
    title = 'app';
    //constructor(public toastr: ToastsManager, vcr: ViewContainerRef) {
    //    this.toastr.setRootViewContainerRef(vcr);
    //}
}
