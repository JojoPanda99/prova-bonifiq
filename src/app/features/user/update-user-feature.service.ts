import {Injectable} from '@angular/core';
import {FormGroup} from "@angular/forms";
import {UserService} from "../../core/services/user.service";
import {ToastrService} from "ngx-toastr";

@Injectable({
    providedIn: 'root'
})
export class UpdateUserFeatureService {

    constructor(private userService: UserService, private toastr: ToastrService) {

    }

    public updateUser(payload: FormGroup): void {
        this.userService.update(payload.value.id, payload.value).subscribe({
            next: (response: any) => {
                this.toastr.success('Usuario atualizado com sucesso!', 'Sucesso!')
                payload.reset()
            },
            error: (err: any) => {
                err.error.messages.forEach((e: string) => this.toastr.error(e));
            }
        });
    }
}
