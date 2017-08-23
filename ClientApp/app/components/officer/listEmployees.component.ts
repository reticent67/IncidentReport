import { Component } from '@angular/core';
import { OfficerService } from '../../services/OfficerService';
import { Response } from '@angular/http'; 

@Component({
    selector: 'list-employees',
    templateUrl: './listEmployees.component.html',
    providers: [OfficerService]
})
 
export class ListEmployeesComponent {
    public EmployeeList = [];
    public constructor(private ofcrService: OfficerService) {
        this.ofcrService.getOfficerList().subscribe((data: Response) => (this.EmployeeList = data.json()));
    }
}   