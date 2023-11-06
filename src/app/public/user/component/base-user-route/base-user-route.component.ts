import {Component} from "@angular/core";

@Component({
    selector: "app-base-user-route",
    template: `
        <div>
            <div class="row gap-5">
                <div class="col-12">
                    <app-create-user></app-create-user>
                </div>
                <div class="col-6">
                    <app-list-user/>
                </div>
                <div class="col-6">
                    <router-outlet></router-outlet>
                </div>
            </div>
        </div>
    `,
    styles: [],
})
export class BaseUserRouteComponent {
    constructor() {
    }
}
