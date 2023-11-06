import {Injectable} from '@angular/core';
import {FormGroup} from "@angular/forms";
import {UserService} from "../../core/services/user.service";
import {ToastrService} from "ngx-toastr";
import {User} from "../../core/models/user.model";
import {Observable, Subject} from "rxjs";
import {Router} from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export class UpdateUserFeatureService {
    user: Subject<User> = new Subject<User>();

    constructor(private userService: UserService, private toastr: ToastrService, private router: Router) {

    }

    public getUser(id: number): Observable<User> {
        return this.userService.getById(id);
    }

    public updateUser(payload: FormGroup): void {
        this.userService.update(payload.value.id, payload.value).subscribe({
            next: (response: any) => {
                this.toastr.success('Usuario atualizado com sucesso!', 'Sucesso!')
                payload.reset()
                this.router.navigateByUrl('/');
            },
            error: (err: any) => {
                err.error.messages.forEach((e: string) => this.toastr.error(e));
            }
        });
    }
}
