import { Component, EventEmitter, Input, Output } from "@angular/core";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-menu",
    templateUrl: "././menu.component.html",
    styleUrls: ['././menu.component.css']
})


export class ProfileMenu {

    @Input() selectedJobGroup: Array<IJobGroupModel> = [];
    @Input() about: string = "";

    @Output() menuSelectionChange = new EventEmitter();

    menuSelectionChanged(menuCode: string) {
        this.menuSelectionChange.emit(menuCode);
    }
}
