import {
    Directive,
    OnChanges,
    OnDestroy,
    OnInit,
    SimpleChanges,
} from "@angular/core";

@Directive()
export abstract class BaseComponent implements OnInit, OnChanges, OnDestroy {
    ngOnChanges(changes: SimpleChanges): void { }
    ngOnDestroy(): void { }
    ngOnInit(): void { }
}
