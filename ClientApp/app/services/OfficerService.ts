import { Injectable, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';


@Injectable()
export class OfficerService {
    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {

    }

    getOfficerList() {
        return this.http.get(this.originUrl + '/api/Officer');
    }

    postData(empObj: any) {
        let headers = new Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });
        return this.http.post(this.originUrl + '/api/Officer', JSON.stringify(empObj), { headers: headers });
    }

    getEmployeeDetails(empID: any) {
        return this.http.get(this.originUrl + '/api/Officer/' + empID);
    }

    editEmployeeData(empObj: any, empID: any) {
        let headers = new Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });
        return this.http.put(this.originUrl + '/api/Officer/' + empID, JSON.stringify(empObj), { headers: headers });
    }

    deleteEmployee(empID: any) {
        let headers = new Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });
        return this.http.delete(this.originUrl + '/api/Officer/' + empID);
    }
}

