import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { ChildrenComponent } from './components/children/children.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { AuthGuard } from './auth.guard';
import { WeeklySystemComponent } from './components/weekly-system/weekly-system.component';
import { CommonModule } from '@angular/common';

import { InsertChildComponent } from './components/insert-child/insert-child.component';



const routes: Routes = [
  {component:LogInComponent,path:""},
  {component:ParentMainComponent,path:"parent-main",canActivate:[AuthGuard]},
  {component:AdminMainComponent,path:"admin-main",canActivate:[AuthGuard],children:[
     {component:ChildrenComponent, path:"children"}
  ]},
  {component:WorkerMainComponent, path:"worker-main",canActivate:[AuthGuard]},
  {component:WelcomeComponent, path:"welcome"},
 
  {component:ParentMainComponent,path:"parent-main"},
  {component:AdminMainComponent,path:"admin-main",
  children:[
    {component:WelcomeComponent,path:""},
     {component:ChildrenComponent, path:"children"},
     {component:WeeklySystemComponent, path:"weekly-system"},
    
  ]},
  {component:WorkerMainComponent, path:"worker-main"},
  // {component:WelcomeComponent, path:"welcome"},
  {component:InsertChildComponent, path:"insert"}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
  CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }

