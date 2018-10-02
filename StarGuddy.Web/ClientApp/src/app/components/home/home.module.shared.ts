import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { HomeComponent } from "./home.component";
import { HomeSearchComponent } from "./search/search.component";
import { HomeProfileComponent } from "./profile/profile.component";
import { HomeCastingComponent } from "./casting/casting.component";
import { HomeNewComersComponent } from "./newComers/newComers.component";
import { HomeReviewComponent } from "./review/review.component";
import { HomeJoblistComponent } from "./joblist/joblist.component";


@NgModule({
    declarations: [
        HomeComponent,
        HomeSearchComponent,
        HomeProfileComponent,
        HomeCastingComponent,
        HomeNewComersComponent,
        HomeReviewComponent,
        HomeJoblistComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forRoot([ 
            { path: "home", component: HomeComponent }
        ])
    ],
    exports: []
})

export class HomeModuleShared {
}
