import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { FormInputUIComponent } from "./form-input/form-input.component";
import { EducationSelectComponent } from './education-select/education-select.component';

@NgModule({
  declarations: [FormInputUIComponent, EducationSelectComponent],
  imports: [CommonModule, ReactiveFormsModule],
  exports: [FormInputUIComponent, EducationSelectComponent],
})
export class UIModule {}
