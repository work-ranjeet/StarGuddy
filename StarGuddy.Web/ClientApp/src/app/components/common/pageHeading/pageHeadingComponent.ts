import { Component, Input } from "@angular/core";

@Component({
    selector: "page-heading",
    template: `<div class="row">
                    <div class="col-md-12">
                        <h2 class="page-title">{{text}}</h2>
                        <sub *ngIf="showInfo" style="font-size:12px;">{{info}}</sub>
                    </div>
                </div>`
})
export class PageHeadingComponent {
    @Input() text?: string;
    @Input() showInfo?: boolean = false;
    @Input() info?: string = "";


}
