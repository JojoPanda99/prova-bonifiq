import {Injectable} from '@angular/core';
import {UserService} from "../../core/services/user.service";
import {map, Observable} from "rxjs";
import {UserFeature} from "../../core/models/user-responses.models";
import {ToastrService} from "ngx-toastr";
import {HttpErrorResponse} from "@angular/common/http";
import {EducationEnum} from "../../shared/enums/education.enum";

@Injectable({
    providedIn: 'root'
})
export class ListUserFeatureService {

    constructor(private userService: UserService, private toastr: ToastrService) {
    }

    public getAll(): Observable<UserFeature[]> {
        return this.userService.getAll()
            .pipe(
                map((users: any) =>
                    users.map((user: any) => ({
                            id: user.id,
                            name: user.name + " " + user.surname,
                            education: EducationEnum[user.education],
                        })
                    )
                )
            );
    }

    public delete(id: number): void {
        this.userService.delete(id).subscribe({
            next: (response: any) => this.toastr.success('Usuario criado com sucesso!', 'Sucesso!'),
            error: (err: HttpErrorResponse) => {
                err.error.message.forEach((e: string) => this.toastr.error(e));
            }

        });
    }
}
