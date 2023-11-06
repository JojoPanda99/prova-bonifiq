import {Injectable} from '@angular/core';
import {UserService} from "../../core/services/user.service";
import {map, Observable} from "rxjs";
import {UserFeature} from "../../core/models/user-responses.models";
import {ListUserFeatureServiceAbstract} from "../../core/abstracts/list-user-feature-service.abstract";

@Injectable({
    providedIn: 'root'
})
export class ListUserFeatureService extends ListUserFeatureServiceAbstract<UserFeature> {

    constructor(private userService: UserService) {
        super();
    }

    public getAll(): Observable<UserFeature[]> {
        return this.userService.getAll()
            .pipe(
                map((users: any) =>
                    users.map((user: any) => ({
                            id: user.id,
                            name: user.name + " " + user.surname,
                            education: user.education,
                        })
                    )
                )
            );
    }

    public delete(id: number): void {
        this.userService.delete(id);
    }
}
