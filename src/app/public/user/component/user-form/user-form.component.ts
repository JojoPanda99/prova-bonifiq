import {Component, EventEmitter, Output} from "@angular/core";
import {FormBuilder, FormControl, FormGroup, Validators,} from "@angular/forms";
import {UserFormControls} from "./user-form.type";
import {BaseComponent} from "../../../../shared/components/base-component.component";

@Component({
    selector: "app-user-form",
    templateUrl: "./user-form.component.html",
    styles: [],
})
export class UserFormComponent extends BaseComponent {
    @Output() formEvent: EventEmitter<any> = new EventEmitter();
    protected userForm!: FormGroup<UserFormControls>;
    protected formControls!: UserFormControls;

    constructor(private fb: FormBuilder) {
        super();
    }

    override ngOnInit(): void {
        this.createFormGroup();
        this.formControls = this.userForm.controls;
    }

    protected submitForm() {
        if (this.userForm.valid) {
            this.formEvent.emit(this.userForm);
        }
    }

    private createFormGroup(): void {
        this.userForm = this.fb.group({
            name: new FormControl("", [Validators.required]),
            surname: new FormControl("", [Validators.required]),
            email: new FormControl("", [Validators.required]),
            birthDate: new FormControl("", [Validators.required]),
            education: new FormControl(0, [Validators.required]),
        });
    }
}
