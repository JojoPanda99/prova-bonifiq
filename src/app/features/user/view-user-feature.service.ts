import {Injectable} from '@angular/core';
import {catchError, map, Observable, of, Subject, tap} from "rxjs";
import {User} from "../../core/models/user.model";
import {UserService} from "../../core/services/user.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {FormGroup} from "@angular/forms";
import {DateUtils} from "../../shared/utils/DateUtils";
import {EducationEnum} from "../../shared/enums/education.enum";

@Injectable({
    providedIn: 'root'
})
export class ViewUserFeatureService {
    constructor(private userService: UserService, private toastr: ToastrService, private router: Router) {
    }

    public getUser(id: number): Observable<User> {
        return this.userService.getById(id)
            .pipe(
                map((user: User) => ({
                    ...user,
                    name: user.name + " " + user.surname,
                    education: EducationEnum[user.education],
                    birthDate: DateUtils.formatViewDate(new Date(user.birthDate))
                })),
                catchError((err: any) => {
                        console.log(err)
                        err.error.messages.forEach((e: any) => {
                            this.toastr.error(e);
                        });
                        this.navigateBack()
                        return of(err);
                    }
                )
            );
    }

    public navigateBack() {
        this.router.navigateByUrl('/');
    }
}
