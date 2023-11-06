import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {PublicRoutingModule} from './public-routing.module';
import {SharedModule} from "../shared/shared.module";

import {CreateUserComponent} from "./user/create-user/create-user.component";
import {ListUserComponent} from "./user/list-user/list-user.component";
import {BaseUserRouteComponent} from "./user/component/base-user-route/base-user-route.component";
import {ListUserFeatureServiceAbstract} from "../core/abstracts/list-user-feature-service.abstract";
import {ListUserFeatureService} from "../features/user/list-user-feature.service";

const USER_COMPONENTS = [CreateUserComponent, ListUserComponent, BaseUserRouteComponent]

@NgModule({
    declarations: [USER_COMPONENTS],
    imports: [
        CommonModule,
        PublicRoutingModule,
        SharedModule,
    ],
    providers: [{
        provide: ListUserFeatureServiceAbstract,
        useClass: ListUserFeatureService
    }]
})
export class PublicModule {
}
