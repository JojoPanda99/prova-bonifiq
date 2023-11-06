import {Component} from "@angular/core";
import {CreateUserFeatureService} from "../../../features/user/create-user-feature.service";
import {FormGroup} from "@angular/forms";

@Component({
    selector: "app-create-user",
    template: `
        <h3>Criar Usuario</h3>
        <app-user-form (formEvent)="submit($event)"></app-user-form>
    `,
    styles: [],
})
export class CreateUserComponent {
    constructor(private createUserFeatureService: CreateUserFeatureService) {
    }

    public submit(payload: FormGroup): void {
        this.createUserFeatureService.createUser(payload);
    }
}
