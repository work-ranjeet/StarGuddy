import { Component } from "@angular/core";

@Component({
    selector: "nav-menu",
    templateUrl: "./navmenu.component.html",
    styleUrls: ["./navmenu.component.css"]
})
export class NavMenuComponent {
    isIn = false;   // store state
    toggleState() { // click handler
        this.isIn = !this.isIn;
    }

    toggleStateOut() {
        this.isIn = !this.isIn;
    }
}
