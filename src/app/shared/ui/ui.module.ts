import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { FormInputUIComponent } from "./form-input/form-input.component";

@NgModule({
  declarations: [FormInputUIComponent],
  imports: [CommonModule, ReactiveFormsModule],
  exports: [FormInputUIComponent],
})
export class UIModule {}
