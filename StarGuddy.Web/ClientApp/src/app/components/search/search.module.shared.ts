import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AuthGuard } from "../../Services/AuthenticationGuard";
import { SearchService } from "./search.Service";
import { SearchIndex } from "./index/index.component";
import { SearchTalentGroupComponent } from "./talentGroup/talentGroup.component";



@NgModule({
    declarations: [
        SearchIndex,
        SearchTalentGroupComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            {
                path: "search",
                canActivate: [AuthGuard],
                children: [
                    { path: "", component: SearchIndex },
                    { path: "groups", component: SearchTalentGroupComponent, canActivateChild: [AuthGuard] }
                ]
            }
        ])
    ],
    providers: [SearchService],
    exports: [SearchIndex, SearchTalentGroupComponent]
})

export class SearchModuleShared {
}
