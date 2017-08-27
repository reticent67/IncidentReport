import { Component, OnInit } from '@angular/core';
import { ReportService } from '../../services/ReportService';
import { ReportPerson, PersonAddress } from '../../models/reportForm.model';
import { Validators, FormGroup, FormArray, FormBuilder } from '@angular/forms';


@Component({
    selector: 'report-people',
    templateUrl: './createIR-people.component.html'
})

export class CreateIRPeopleComponent implements OnInit {
    title = 'Add the People Involved';
    formShell: FormGroup;
    index: number;
  
   
    
    constructor(private reportFormDataService: ReportService, private _fb: FormBuilder) {
   
    }

   ngOnInit() {
        
        this.formShell = this._fb.group({
            people : this._fb.array([
                this.initPerson(),
            ])
        });

    }
    
    initPerson() {
        return this._fb.group({
            lastName : [''],
            firstName : [''],
            middleName : [''],
            addresses: this._fb.array([
               this.initAddress()
            ])
        });
    }

    addPerson() {
        const personArray = <FormArray>this.formShell.controls['people'];
        personArray.push(this.initPerson());
    }

    removePerson(index: number) {
        const personArray = <FormArray>this.formShell.controls['people'];
        personArray.removeAt(index);
    }

    initAddress() {
        return this._fb.group({
            street: ['']
        });
    }

    addAddress(person: FormGroup) {
        const addressArray = <FormArray>person.controls['addresses'];
        addressArray.push(this.initAddress());
        
    }

    removeAddress(person: FormGroup, index: number) {
        const addressArray = <FormArray>person.controls['addresses'];
        addressArray.removeAt(index);

    }


    save(form: any) {
        var reportPersonList: ReportPerson[] = new Array();
        var people = form.get('people') as FormArray;

        for (let i = 0; i < people.length; i++) {
            var p = new ReportPerson;
            p.lastName = people.at(i).get('lastName').value;
            p.firstName = people.at(i).get('firstName').value;
            p.middleName = people.at(i).get('middleName').value;
            var addresses = people.at(i).get('addresses') as FormArray;
            for (let j = 0; j < addresses.length; j++) {
                var a = new PersonAddress;
                a.street = addresses.at(j).get('street').value;
                p.addresses.push(a);
            };
            reportPersonList.push(p);
        }
        this.reportFormDataService.setReportPeople(reportPersonList);
       
    }
   
}