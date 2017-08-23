import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutes } from './app.routes'



//Components
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { DetailsComponent } from './components/officer/details.component';
import { EditEmployeeComponent } from './components/officer/editEmployee.component';
import { NewEmployeeComponent } from './components/officer/newEmployee.component';
import { ListEmployeesComponent } from './components/officer/listEmployees.component';
import { DeleteEmployeeComponent } from './components/officer/deleteEmployee.component';
import { FilterSearch } from './pipes/search';
import { CreateIRAppComponent } from './components/createIR/createIR-app.component';
import { CreateIRDetailsComponent } from './components/createIR/createIR-details.component';
import { CreateIRPeopleComponent } from './components/createIR/createIR-people.component';
import { CreateIRMenuComponent } from './components/createIR/createIR-menu.component';



//Services
import { OfficerService } from './services/OfficerService';



export const sharedConfig: NgModule = {
    bootstrap : [AppComponent],
    declarations : [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        //Officer Components
        ListEmployeesComponent,
        DetailsComponent,
        EditEmployeeComponent,
        NewEmployeeComponent,
        DeleteEmployeeComponent,
        FilterSearch,

        CreateIRAppComponent,
        CreateIRDetailsComponent,
        CreateIRPeopleComponent,
        CreateIRMenuComponent
       
        
    ],
    providers : [
        OfficerService
    ],

    imports : [
        AppRoutes,
        ReactiveFormsModule,
        FormsModule
    ]
};

//RouterModule.forRoot([
//    { path: '', redirectTo: 'home', pathMatch: 'full' },
//    { path: 'home', component: HomeComponent },
//    { path: 'officer/details/:id', component: DetailsComponent },
//    { path: 'officer/create', component: NewEmployeeComponent },
//    { path: 'officer/edit/:id', component: EditEmployeeComponent },
//    { path: 'officer/delete/:id', component: DeleteEmployeeComponent },
//    { path: 'officer', component: ListEmployeesComponent },

//    { path: 'createIR', component: CreateIRAppComponent },

//    { path: '**', redirectTo: 'home' }
//]),