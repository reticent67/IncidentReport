import { Component } from '@angular/core';
import { OfficerService } from '../../services/OfficerService';
import { Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';  


@Component({
    selector: 'edit-employee',
    templateUrl: './editEmployee.component.html',
    providers: [OfficerService]
})
export class EditEmployeeComponent {
    private OfficerID: number;
    public EmployeeDetails = {};
    public EmployeeName: string;
    public formData: FormGroup;

    public constructor(private ofcrService: OfficerService, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.OfficerID = params['id'];
        });

        this.formData = new FormGroup({
            'OfficerID' : new FormControl(),
            'Serial': new FormControl('', [Validators.required]),
            'LastName': new FormControl('', Validators.required),
            'FirstName': new FormControl('', Validators.required),
            'Division': new FormControl('', [Validators.required]),
            'Assignment': new FormControl('', [Validators.required])
        });
   

        this.ofcrService.getEmployeeDetails(this.OfficerID)
            .subscribe((data: Response) => (
                this.formData.patchValue({ OfficerID : data.json().officerID }),
                this.formData.patchValue({ Serial : data.json().serial }),
                this.formData.patchValue({ LastName : data.json().lastName }),
                this.formData.patchValue({ FirstName : data.json().firstName }),
                this.formData.patchValue({ Division : data.json().division }),
                this.formData.patchValue({ Assignment : data.json().assignment })));
    }

    submitData() {
        if (this.formData.valid) {
            var Obj = {
                OfficerID: this.formData.value.OfficerID,
                Serial: this.formData.value.Serial,
                LastName: this.formData.value.LastName,
                FirstName: this.formData.value.FirstName,
                Division: this.formData.value.Division,
                Assignment: this.formData.value.Assignment
            };
            this.ofcrService.editEmployeeData(Obj, this.OfficerID).subscribe();
            alert("Employee Updated Successfully");
        }
    }
}  