import {Component} from "@angular/core";
import {UserService} from "src/app/core/services/user.service";

@Component({
    selector: "app-create-user",
    template: `
        <h3>Criar Usuario</h3>
        <app-user-form (formEvent)="submit($event)"></app-user-form>
    `,
    styles: [],
})
export class CreateUserComponent {
    private user!: any;

    constructor(private userService: UserService) {
    }

    public submit(payload: any): void {
        console.log(payload);
    }
}
