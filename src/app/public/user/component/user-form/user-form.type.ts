import { FormControl } from "@angular/forms";

export type UserForm = {
  name: string;
  surname: string;
  email: string;
  birthDate: string;
  education: number;
};
export type UserFormControls = {
  [K in keyof UserForm]: FormControl<UserForm[K] | null>;
};
