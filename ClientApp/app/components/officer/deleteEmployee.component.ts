import { Component } from '@angular/core';
import { OfficerService } from '../../services/OfficerService';
import { Response } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router'

@Component({
    selector: 'delete-employee',
    templateUrl: './deleteEmployee.component.html',
    providers: [OfficerService]
})

export class DeleteEmployeeComponent {
    private EmpID: number;
    public EmployeeDetails = [];
    public OfficerList = [];

    public constructor(private ofcrService: OfficerService, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.EmpID = params['id'];
        });
        this.ofcrService.getEmployeeDetails(this.EmpID)
            .subscribe((data: Response) => (this.EmployeeDetails["serial"] = data.json().serial,
                this.EmployeeDetails["lastName"] = data.json().lastName,
                this.EmployeeDetails["firstName"] = data.json().firstName,
                this.EmployeeDetails["division"] = data.json().division,
                this.EmployeeDetails["assignment"] = data.json().assignment,
                this.EmployeeDetails["officerID"] = data.json().officerID));
    }
    

    deleteEmployee(empID: number) {
        var status = confirm("Are you sure you want to delete this employee?");
        if (status) {
            this.ofcrService.deleteEmployee(empID)
                .subscribe(() => (alert("Employee deleted successfully")));

            this.ofcrService.getOfficerList().subscribe((data: Response) => (this.OfficerList = data.json()));
        }
    }
}