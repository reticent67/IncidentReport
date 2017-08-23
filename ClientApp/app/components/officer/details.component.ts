import { Component } from '@angular/core';
import { OfficerService } from '../../services/OfficerService';
import { Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router'


@Component({
    selector: 'employee-detail',
    templateUrl: './details.component.html',
    providers: [OfficerService],
})
export class DetailsComponent {
    private EmpID: number;
    public EmployeeDetails = {};
    public constructor(private ofcrService: OfficerService, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.EmpID = params['id'];
        });

        this.ofcrService.getEmployeeDetails(this.EmpID)
            .subscribe((data: Response) => (this.EmployeeDetails["serial"] = data.json().serial,
                this.EmployeeDetails["lastName"] = data.json().lastName,
                this.EmployeeDetails["firstName"] = data.json().firstName,
                this.EmployeeDetails["division"] = data.json().division,
                this.EmployeeDetails["assignment"] = data.json().assignment));
    }



}   