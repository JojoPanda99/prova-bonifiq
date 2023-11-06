import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListUserComponent} from "./user/list-user/list-user.component";
import {CreateUserComponent} from "./user/create-user/create-user.component";

const routes: Routes = [
    {
        path: "view/:id",
        component: ListUserComponent,
    },
    {
        path: "create",
        component: CreateUserComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PublicRoutingModule {
}
