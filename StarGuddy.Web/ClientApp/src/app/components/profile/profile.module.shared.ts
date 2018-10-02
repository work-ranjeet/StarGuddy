import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { ProfileService } from "../profile/profile.Service";
import { ProfileHeader } from "../profile/header/header.component";
import { ProfileIndex } from "../profile/index/index.component";
import { ProfileMenu } from "../profile/menu/menu.component";
import { ProfilePhotosComponent } from "../profile/photos/photos.component";
import { PhysicalDetailsComponent } from "../profile/physicalDetails/physicalDetails.component";
import { ProfileCreditsComponent } from "../profile/credits/credits.component";
import { ProfileActingComponent } from "../profile/acting/acting.component";
import { ProfileDancingComponent } from "../profile/dancing/dancing.component";
import { ProfileModelingComponent } from "../profile/modeling/modeling.component";

@NgModule({
    declarations: [
        ProfileIndex,
        ProfileHeader,
        ProfileMenu,
        ProfilePhotosComponent, PhysicalDetailsComponent, ProfileCreditsComponent,
        ProfileActingComponent, ProfileDancingComponent, ProfileModelingComponent
    ],
    imports: [        
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile/star/:profileUrl", component: ProfileIndex }
        ])
    ],
    providers: [ProfileService],
    exports: [
        ProfileIndex, ProfileHeader, ProfileMenu, 
        ProfilePhotosComponent, PhysicalDetailsComponent, ProfileCreditsComponent,
        ProfileActingComponent, ProfileDancingComponent, ProfileModelingComponent
    ]
})

export class ProfileModuleShared {
}
