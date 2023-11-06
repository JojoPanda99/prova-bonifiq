import {Component, Input} from "@angular/core";
import {FormControl} from "@angular/forms";

type InputTypes = "text" | "date" | "password" | "email" | "number";

@Component({
    selector: "form-input-ui",
    template: `
        <div class="form-group">
            <label [attr.for]="name" class="form-label">{{ label }}</label>
            <input
                    [formControl]="control"
                    [attr.type]="type"
                    class="form-control"
                    [attr.name]="name"
                    [ngClass]="{'is-invalid': validateRequired()}"
            />
            <span class="invalid-feedback" *ngIf="validateRequired()">Este campo é obrigatório</span>
        </div>
    `,
    styles: [],
})
export class FormInputUIComponent {
    @Input({required: true}) label!: string;
    @Input({required: true}) control!: FormControl;
    @Input({required: true}) name!: string;
    @Input() type: InputTypes = "text";

    protected validateRequired = (): boolean =>
        this.control.hasError("required") && this.control.touched;
}
