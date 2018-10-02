import { Component, Input } from "@angular/core";

@Component({
    selector: "heading",
    template: `<div class="row">
                    <div class="col-md-12 main-heading-container">
                        <h4 class="{{hasClass() ? cssClass : 'main-heading'}}">{{text}}</h4>
                    </div>
                </div>`
})
export class HeadingComponent {
    @Input() text?: string;
    @Input() cssClass?: string;

    hasClass(): boolean {
        return this.cssClass != undefined && this.cssClass != null;
    }
}
