import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OfficerService } from '../../services/OfficerService';

@
Component({
    selector : 'new-employee',
    templateUrl : './newEmployee.component.html',
    providers: [OfficerService]
    })

export class NewEmployeeComponent {
    public formData: FormGroup;

    public constructor(private ofcrService: OfficerService) {

        this.formData = new FormGroup({
            'Serial' : new FormControl('', [Validators.required]),
            'LastName' : new FormControl('', Validators.required),
            'FirstName' : new FormControl('', Validators.required),
            'Division' : new FormControl('', [Validators.required]),
            'Assignment' : new FormControl('', [Validators.required])
        });
    }

    submitData() {
        if (this.formData.valid) {
            var Obj = {
                Serial : this.formData.value.Serial,
                LastName : this.formData.value.LastName,
                FirstName : this.formData.value.FirstName,
                Division: this.formData.value.Division,
                Assignment: this.formData.value.Assignment
            };
            this.ofcrService.postData(Obj).subscribe();
            alert("Employee Inserted Successfully");
        }
    }
}