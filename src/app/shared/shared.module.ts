import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {UIModule} from "./ui/ui.module";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
    declarations: [],
    imports: [CommonModule, UIModule, ReactiveFormsModule],
    exports: [UIModule],
})
export class SharedModule {
}
