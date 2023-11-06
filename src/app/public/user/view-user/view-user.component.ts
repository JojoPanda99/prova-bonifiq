import {Component} from '@angular/core';
import {ViewUserFeatureService} from "../../../features/user/view-user-feature.service";
import {BaseComponent} from "../../../shared/components/base-component.component";
import {Observable} from "rxjs";
import {User} from "../../../core/models/user.model";
import {ActivatedRoute, Params, Router} from "@angular/router";

@Component({
    selector: 'app-view-user',
    template: `
        <h3>Usuario</h3>
        <p class="btn" (click)="navigateBack()">
            Voltar
        </p>
        <div class="card">
            <div class="card-header">
                <h4>{{ (user | async)?.name }}</h4>
            </div>
            <div class="card-body">
                <h5>Email</h5>
                <h6 class="card-text">{{ (user | async)?.email }}</h6>
                <h5>Escolaridade</h5>
                <h6 class="card-text">{{ (user | async)?.education}}</h6>
                <h5>Data de Nascimento</h5>
                <h6 class="card-text">{{ (user | async)?.birthDate }}</h6>
            </div>
        </div>
    `,
    styles: []
})
export class ViewUserComponent extends BaseComponent {
    protected user!: Observable<User>;

    constructor(private viewUserFeature: ViewUserFeatureService,
                private activeRoute: ActivatedRoute,
    ) {
        super();
    }

    override ngOnInit() {
        this.activeRoute.params.subscribe(({id}: Params) => {
            this.user = this.viewUserFeature.getUser(id);
        });
    }

    public navigateBack = () => this.viewUserFeature.navigateBack();
}
