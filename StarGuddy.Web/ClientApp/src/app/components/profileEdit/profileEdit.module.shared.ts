import { CommonModule } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ImageCropperModule } from "ngx-image-cropper";
import { MatStepperModule, MatInputModule, MatButtonModule, MatAutocompleteModule, MatCardModule, MatCheckboxModule, MatSelectModule, MatRadioModule, MatDialogModule } from "@angular/material";

import { AuthGuard } from "../../Services/AuthenticationGuard";
import { ProfileEditActingComponent } from "./acting/profileEditActing.component";
import { ProfileEditAddressComponent } from "./address/profileEditAddress.component";
import { ProfileEditCreditsComponent } from "./credits/profileEditCredits.component";
import { ProfileEditDancingComponent } from "./dancing/profileEditDancing.component";
import { ProfileEditHeader } from "./header/profileEditHeader.component";
import { ProfileHeadShotComponent } from "./headShot/headShot.component";
import { ProfileEditIndex } from "./index/profileEditIndex.component";
import { ProfileEditIntroComponent } from "./intro/profileEditIntro.component";
import { JobGroupComponent } from "./jobGroup/JobGroup.component";
import { ProfileEditMenu } from "./menu/profileEditMenu.component";
import { ProfileEditModelingComponent } from "./modeling/profileEditModeling.component";
import { ProfileEditNameComponent } from "./name/profileEditName.component";
import { ProfileEditPhotosComponent } from "./photos/profileEditPhotos.component";
import { ProfileEditPhysicalComponent } from "./physicalDetails/profileEditPhysical.component";
import { ProfileEditService } from "./profileEdit.Service";
import { ProfileEditTrainingsComponent } from "./trainings/profileEditTrainings.component";
import { ProfileEditPhotosManagerComponent } from "./photosManager/photosManager.component";
import { ProfilePhotoUploadComponent } from "./photoUpload/photoUpload.component";
import { ProfileEditCaptionComponent } from "./caption/caption.component";



@NgModule({
    declarations: [
        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent, ProfilePhotoUploadComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent, ProfileEditAddressComponent, ProfileEditPhotosManagerComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent, ProfileEditNameComponent, ProfileEditIntroComponent, ProfileEditCaptionComponent,
        ProfileHeadShotComponent
    ],
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule, ImageCropperModule,
        MatStepperModule, MatInputModule, MatButtonModule, MatAutocompleteModule, MatCardModule, MatCheckboxModule, MatSelectModule, MatRadioModule, MatDialogModule,
        RouterModule.forRoot([
            {
                path: "profile",
                children: [
                    { path: "", redirectTo: "edit", pathMatch: "full" },
                    { path: "edit", component: ProfileEditIndex, canActivate: [AuthGuard] },
                    { path: "name", component: ProfileEditNameComponent, canActivate: [AuthGuard] },
                    { path: "intro", component: ProfileEditIntroComponent, canActivateChild: [AuthGuard] },
                    { path: "address", component: ProfileEditAddressComponent, canActivateChild: [AuthGuard] },
                    { path: "interests", component: JobGroupComponent, canActivateChild: [AuthGuard] },
                    { path: "photoManager", component: ProfileEditPhotosManagerComponent, canActivateChild: [AuthGuard] },
                    { path: "photoUpload", component: ProfilePhotoUploadComponent, canActivateChild: [AuthGuard] },
                    { path: "head-shot/:?gender", component: ProfileHeadShotComponent, canActivateChild: [AuthGuard] }
                ]
            }
        ])
    ],
    providers: [ProfileEditService],
    exports: [

        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent, ProfilePhotoUploadComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent, ProfileEditAddressComponent, ProfileEditPhotosManagerComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent, ProfileEditNameComponent, ProfileEditIntroComponent, ProfileEditCaptionComponent,
        ProfileHeadShotComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProfileEditModuleShared {
}
