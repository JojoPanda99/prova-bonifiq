import {Component} from "@angular/core";
import {Observable} from "rxjs";
import {BaseComponent} from "src/app/shared/components/base-component.component";
import {ListUserFeatureService} from "../../../features/user/list-user-feature.service";
import {UserFeature} from "../../../core/models/user-responses.models";
import {ListUserFeatureServiceAbstract} from "../../../core/abstracts/list-user-feature-service.abstract";

@Component({
    selector: "app-list-user",
    template: `
        <div class="container">
            <table class="table table-striped text-center">
                <thead>
                <th scope="col">Nome</th>
                <th scope="col">Escolaridade</th>
                </thead>
                <tbody>
                <tr
                        *ngFor="let user of users$ | async"
                        routerLinkActive="g-info-subtle"
                >
                    <td>{{ user.name }}</td>
                    <td>{{ user.education }}</td>
                    <td class="d-flex w-50 justify-content-between">
                        <button class="btn btn-dark" [routerLink]="['/view', user.id]">
                            Ver
                        </button>
                        <button class="btn btn-warning" [routerLink]="['/edit', user.id]">
                            Editar
                        </button>
                        <button class="btn btn-danger" (click)="deleteUser(user.id)">
                            Remover
                        </button>
                    </td>
                </tr>
                </tbody>
            </table>
            <nav aria-label="Page navigation example">
                <ul class="pagination justify-content-end">
                    <li class="page-item disabled">
                        <button class="btn mx-2">Anterior</button>
                    </li>
                    <li class="page-item">
                        <button class="btn mx-2">Proxima</button>
                    </li>
                </ul>
            </nav>
        </div>
    `,
    styles: [],
})
export class ListUserComponent extends BaseComponent {
    protected users$!: Observable<UserFeature[]>;

    constructor(private userListFeature: ListUserFeatureService) {
        super();
    }

    override ngOnInit(): void {
        this.users$ = this.userListFeature.getAll();
    }

    protected deleteUser(userId: number) {
        this.userListFeature.delete(userId);
    }
}
