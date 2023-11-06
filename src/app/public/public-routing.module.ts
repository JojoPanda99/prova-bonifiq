import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListUserComponent} from "./user/list-user/list-user.component";
import {CreateUserComponent} from "./user/create-user/create-user.component";
import {UpdateUserComponent} from "./user/update-user/update-user.component";
import {BaseUserRouteComponent} from "./user/component/base-user-route/base-user-route.component";
import {ViewUserComponent} from "./user/view-user/view-user.component";

const routes: Routes = [
    {
        path: "",
        component: BaseUserRouteComponent,
        children: [
            {
                path: "view/:id",
                component: ViewUserComponent,
            },
            {
                path: "",
                outlet: "form",
                component: CreateUserComponent,
            },
            {
                path: ":id",
                outlet: "form",
                component: UpdateUserComponent,
            },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PublicRoutingModule {
}
