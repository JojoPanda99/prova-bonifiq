import {Injectable} from '@angular/core';
import {FormGroup} from "@angular/forms";
import {UserService} from "../../core/services/user.service";
import {ToastrService} from "ngx-toastr";
import {User} from "../../core/models/user.model";
import {map, Observable, Subject} from "rxjs";
import {Router} from "@angular/router";
import {DateUtils} from "../../shared/utils/DateUtils";
import {ListUserComponent} from "../../public/user/list-user/list-user.component";

@Injectable({
    providedIn: 'root'
})
export class UpdateUserFeatureService {
    user: Subject<User> = new Subject<User>();

    constructor(private userService: UserService, private toastr: ToastrService, private router: Router) {

    }

    public getUser(id: number): Observable<User> {
        return this.userService.getById(id)
            .pipe(
                map((response: User) => {
                    return {
                        id: response.id,
                        name: response.name,
                        surname: response.surname,
                        education: response.education,
                        email: response.email,
                        birthDate: DateUtils.DatetimeToDate(new Date(response.birthDate))
                    }
                })
            );
    }

    public updateUser(payload: FormGroup): void {
        this.userService.update(payload.value.id, {
            id: payload.value.id,
            name: payload.value.name,
            surname: payload.value.surname,
            education: Number(payload.value.education),
            email: payload.value.email,
            birthDate: payload.value.birthDate
        }).subscribe({
            next: (response: any) => {
                this.toastr.success('Usuario atualizado com sucesso!', 'Sucesso!')
                payload.reset()
                ListUserComponent.usersUpdate.next(null);
                this.router.navigateByUrl('/');
            },
            error: (err: any) => {
                err.error.messages.forEach((e: string) => this.toastr.error(e));
            }
        });
    }
}
