import { Component, OnInit, Input } from '@angular/core';
import { ReportService } from '../../services/ReportService';


@Component({
    selector: 'createIR-app',
    templateUrl: './createIR-app.component.html',
    styleUrls:['./createIR.css'],
    providers: [ReportService]
    
})

export class CreateIRAppComponent implements OnInit {
    title = 'Enter Report Details';
    @Input() reportFormData; 
    
    constructor(private reportService: ReportService) {
        
    }

    ngOnInit() {
       this.reportFormData = this.reportService.getFormData();
    }
    
}


