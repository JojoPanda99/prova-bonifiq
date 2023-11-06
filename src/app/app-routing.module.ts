import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {BaseUserRouteComponent} from "./public/user/component/base-user-route/base-user-route.component";

const routes: Routes = [
    {
        path: "",
        component: BaseUserRouteComponent,
        loadChildren: () =>
            import("./public/public.module").then((m) => m.PublicModule),
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {
}
