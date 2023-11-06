import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {CrudService} from "../interfaces/crud-service.interface";
import {UserGetAllResponse} from "../models/user-responses.models";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {User} from "../models/user.model";

@Injectable({
    providedIn: "root",
})
export class UserService extends CrudService<User, UserGetAllResponse> {
    constructor(private httpClient: HttpClient) {
        super();
    }

    create(data: Partial<User>): Observable<User> {
        return this.httpClient.post<User>(`${environment.BASE_URL}/v1/user`, data);
    }

    delete(id: number): Observable<unknown> {
        return this.httpClient
            .delete(`${environment.BASE_URL}/v1/user/${id}`);
    }

    getAll(): Observable<UserGetAllResponse[]> {
        return this.httpClient
            .get<UserGetAllResponse[]>(`${environment.BASE_URL}/v1/user`);
    }

    getById(id: number): Observable<User> {
        return this.httpClient
            .get<User>(`${environment.BASE_URL}/v1/user/${id}`);
    }

    update(id: number, data: User): Observable<User> {
        return this.httpClient
            .put<User>(`${environment.BASE_URL}/v1/user/${id}`, data);
    }
}
