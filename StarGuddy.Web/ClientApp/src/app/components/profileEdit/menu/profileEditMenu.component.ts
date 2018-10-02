import { Component, EventEmitter, Input, Output } from "@angular/core";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-edit-menu",
    templateUrl: "././profileEditMenu.component.html",
    styleUrls: ['././profileEditMenu.component.css']
})


export class ProfileEditMenu {

    @Input() selectedJobGroup: Array<IJobGroupModel> = [];
    @Input() about: string = "";

    @Output() menuSelectionChange = new EventEmitter();

    menuSelectionChanged(menuCode: string) {
        this.menuSelectionChange.emit(menuCode);
    }
}
