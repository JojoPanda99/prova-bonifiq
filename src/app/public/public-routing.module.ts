import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListUserComponent} from "./user/list-user/list-user.component";
import {CreateUserComponent} from "./user/create-user/create-user.component";
import {UpdateUserComponent} from "./user/update-user/update-user.component";

const routes: Routes = [
    {
        path: "view/:id",
        component: ListUserComponent,
    },
    {
        path: "create",
        component: CreateUserComponent,
    },
    {
        path: "update/:id",
        component: UpdateUserComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PublicRoutingModule {
}
