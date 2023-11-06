import {Component, Input} from '@angular/core';
import {FormControl} from "@angular/forms";
import {EducationSelect} from "../../enums/education.enum";

@Component({
    selector: 'education-select-ui',
    template: `
        <div class="form-group">
            <label [attr.for]="name" class="form-label">{{ label }}</label>
            <select
                    [formControl]="control"
                    class="form-control"
                    [attr.name]="name"
                    [ngClass]="{'is-invalid': validateRequired()}"
            >
                <option [value]="NaN">Selecione</option>
                <option *ngFor="let education of educations" [value]="education.value">{{ education.label }}</option>
            </select>
            <span class="invalid-feedback" *ngIf="validateRequired()">Este campo é obrigatório</span>
        </div>
    `,
    styles: []
})
export class EducationSelectComponent {

    @Input({required: true}) label!: string;
    @Input({required: true}) control!: FormControl;
    @Input({required: true}) name!: string;

    protected educations: any[] = EducationSelect;
    protected validateRequired = (): boolean =>
        this.control.hasError("required") && this.control.touched;
    protected readonly NaN = NaN;
}
