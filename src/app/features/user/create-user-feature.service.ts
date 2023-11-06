import {Injectable} from '@angular/core';
import {UserService} from "../../core/services/user.service";
import {FormGroup} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

@Injectable({
    providedIn: 'root'
})
export class CreateUserFeatureService {

    constructor(private userService: UserService, private toastr: ToastrService) {
    }

    public createUser(payload: FormGroup): void {
        this.userService.create(payload.value).subscribe({
            next: (response: any) => {
                this.toastr.success('Usuario criado com sucesso!', 'Sucesso!')
                payload.reset()
            },
            error: (err: any) => {
                err.error.messages.forEach((e: string) => this.toastr.error(e));
            }
        });
    }
}
