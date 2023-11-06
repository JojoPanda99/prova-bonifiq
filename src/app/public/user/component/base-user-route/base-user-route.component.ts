import {Component} from "@angular/core";

@Component({
    selector: "app-base-user-route",
    template: `
        <div>
            <div class="row gap-4">
                <div class="col-12">
                    <router-outlet name="form"></router-outlet>
                </div>
                <div class="col-5">
                    <app-list-user/>
                </div>
                <div class="col-5">
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
