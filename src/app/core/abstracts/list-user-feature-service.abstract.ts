import {Observable} from "rxjs";


export abstract class ListUserFeatureServiceAbstract<T> {
    abstract delete(id: number): void

    abstract getAll(): Observable<T[]>
}