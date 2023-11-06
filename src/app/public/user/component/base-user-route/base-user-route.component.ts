import { Component } from "@angular/core";

@Component({
  selector: "app-base-user-route",
  template: `
    <div>
      <div class="row">
        <div class="col-6"><app-list-user /></div>
        <div class="col-6"><router-outlet></router-outlet></div>
      </div>
    </div>
  `,
  styles: [],
})
export class BaseUserRouteComponent { }
