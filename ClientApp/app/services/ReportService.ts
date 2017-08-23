import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';
import { ReportFormData, ReportDetails, ReportCars, ReportItems, ReportOfficers, ReportPerson, ReportWeapons, PersonAddress } from '../models/reportForm.model';

@Injectable()
export class ReportService {
    private reportFormData : ReportFormData = new ReportFormData();
    
   

    getReportDetails(): ReportDetails {
        let reportInfo: ReportDetails = {
            reportTitle : this.reportFormData.reportTitle,
            incidentNum : this.reportFormData.incidentNum,
            occurranceLoc : this.reportFormData.occurranceLoc,
            occurranceStart : this.reportFormData.occurranceStart,
            occurranceEnd : this.reportFormData.occurranceEnd,
            reportSummary : this.reportFormData.reportSummary
        };
        return reportInfo;
       
    }

    setReportDetails(data: ReportDetails) {
        this.reportFormData.reportTitle = data.reportTitle;
        this.reportFormData.incidentNum = data.incidentNum;
        this.reportFormData.occurranceLoc = data.occurranceLoc;
        this.reportFormData.occurranceStart = data.occurranceStart;
        this.reportFormData.occurranceEnd = data.occurranceEnd;
        this.reportFormData.reportSummary = data.reportSummary;

    }

    getReportPeople(): ReportPerson[] {
        let reportPersonList: ReportPerson[];
        let p: ReportPerson;
        let addressList: PersonAddress[];
        let a: PersonAddress;
        
        if (this.reportFormData.people != null) {
            for (let per of this.reportFormData.people) {
               // p.id = per.id;
               // p.personRole = per.personRole;
               // p.idNumber = per.idNumber;
               // p.idState = per.idState;
                p.lastName = per.lastName;
                p.firstName = per.firstName;
                p.middleName = per.middleName;
                //p.gender = per.gender;
                //p.race = per.race;
                //p.hairColor = per.hairColor;
                //p.eyeColor = per.eyeColor;
                //p.height = per.height;
                //p.weight = per.weight;
                //p.dateOfBirth = per.dateOfBirth;
                //p.age = per.age;
                //p.clothing = per.clothing;
                //p.phoneNumber = per.phoneNumber;
                //p.email = per.email;
                //p.ssNumber = per.ssNumber;

                for (let add of per.addresses) {
                    a.addressType = add.addressType;
                    a.street = add.street;
                    //a.city = add.city;
                    //a.state = add.state;
                    //a.zipCode = add.zipCode;
                    addressList.push(a);
                }
                reportPersonList.push(p);
            }
        }
        else p = new ReportPerson();
        reportPersonList.push(p);
        
            return reportPersonList;
       

    }

    setReportPeople(data: ReportPerson[]) {
        this.reportFormData.people = data;

        //for (let i = 0; i < form.length; i++) {
        //    console.log(form.length);
        //    console.log(form[i].lastName);
        //    //this.reportFormData.people[i].personRole = data[i].personRole;
        //    //this.reportFormData.people[i].idNumber = data[i].idNumber;
        //    //this.reportFormData.people[i].idState = data[i].idState;
        //    this.reportFormData.people[i].lastName = form[i].lastName;
        //    this.reportFormData.people[i].firstName = form[i].firstName;
        //    this.reportFormData.people[i].middleName = form[i].middleName;
        //    //this.reportFormData.people[i].gender = data[i].gender;
        //    //this.reportFormData.people[i].race = data[i].race;
        //    //this.reportFormData.people[i].hairColor = data[i].hairColor;
        //    //this.reportFormData.people[i].eyeColor = data[i].eyeColor;
        //    //this.reportFormData.people[i].height = data[i].height;
        //    //this.reportFormData.people[i].weight = data[i].weight;
        //    //this.reportFormData.people[i].dateOfBirth = data[i].dateOfBirth;
        //    //this.reportFormData.people[i].age = data[i].age;
        //    //this.reportFormData.people[i].clothing = data[i].clothing;
        //    //this.reportFormData.people[i].phoneNumber = data[i].phoneNumber;
        //    //this.reportFormData.people[i].email = data[i].email;
        //    //this.reportFormData.people[i].ssNumber = data[i].ssNumber;

        //    for (let j = 0; j < this.reportFormData.people[i].addresses.length; j++) {
        //        this.reportFormData.people[i].addresses[j] = form[i].addresses[j];
        //    }
        //    this.reportFormData.people.push()
        //}


    }

    getFormData(): ReportFormData {
        return this.reportFormData;
    }

}