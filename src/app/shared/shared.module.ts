import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UIModule } from "./ui/ui.module";
import { UserFormComponent } from "./components/user-form/user-form.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [UserFormComponent],
  imports: [CommonModule, UIModule, ReactiveFormsModule],
  exports: [UIModule, UserFormComponent],
})
export class SharedModule {}
