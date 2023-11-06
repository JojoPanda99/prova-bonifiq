import {Component} from '@angular/core';
import {FormGroup} from "@angular/forms";
import {UpdateUserFeatureService} from "../../../features/user/update-user-feature.service";
import {ActivatedRoute, Router} from "@angular/router";
import {BaseComponent} from "../../../shared/components/base-component.component";
import {Observable} from "rxjs";
import {User} from "../../../core/models/user.model";

@Component({
    selector: 'app-update-user',
    template: `
        <h3>Alterar Usuario</h3>
        <app-user-form [userValue]="user" (formEvent)="submit($event)"></app-user-form>
    `,
    styles: []
})
export class UpdateUserComponent extends BaseComponent {
    protected user!: Observable<User>;
    protected id!: number;

    constructor(private createUserFeatureService: UpdateUserFeatureService, private routerActivate: ActivatedRoute, private router: Router) {
        super();
    }

    override ngOnInit() {
        this.routerActivate.params.subscribe(({id}) => {
            if (!id) this.router.navigateByUrl('/');
            this.id = id;
            this.user = this.createUserFeatureService.getUser(id);
        });
    }

    public submit(payload: FormGroup): void {
        payload.value.id = this.id;
        this.createUserFeatureService.updateUser(payload);
    }
}
