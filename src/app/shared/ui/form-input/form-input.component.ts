import { Component, Input } from "@angular/core";
import { FormControl } from "@angular/forms";

type InputTypes = "text" | "date" | "password" | "email" | "number";

@Component({
  selector: "form-input-ui",
  template: `
    <label [attr.for]="name" class="form-label">{{ label }}</label>
    <input
      [formControl]="control"
      [attr.type]="type"
      class="form-control"
      [attr.name]="name"
    />
  `,
  styles: [],
})
export class FormInputUIComponent {
  @Input({ required: true }) label!: string;
  @Input({ required: true }) control!: FormControl;
  @Input({ required: true }) name!: string;
  @Input() type: InputTypes = "text";
}
