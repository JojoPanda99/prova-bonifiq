import {Observable} from "rxjs";

export abstract class CrudService<T, TALL = T> {
    abstract getAll(): Observable<T[] | TALL[]>;

    abstract getById(id: number): Observable<T>;

    abstract create(data: T): Observable<T>;

    abstract update(id: number, data: T): Observable<T>;

    abstract delete(id: number): Observable<unknown>;
}