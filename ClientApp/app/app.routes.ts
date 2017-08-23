import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';


import { CreateIRAppComponent } from './components/createIR/createIR-app.component';
import { CreateIRDetailsComponent } from './components/createIR/createIR-details.component';
import { CreateIRPeopleComponent } from './components/createIR/createIR-people.component';


export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: 'createIR', component: CreateIRAppComponent,
        children: [
            { path: '', redirectTo: 'createIR-details', pathMatch: 'full' },
            { path: 'createIR-details', component: CreateIRDetailsComponent },
            { path: 'createIR-people', component: CreateIRPeopleComponent},
        ]
    },
    { path: '**', redirectTo: 'home' }
];

export const AppRoutes = RouterModule.forRoot(routes);