import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { ChildrenComponent } from './components/children/children.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { WeeklySystemComponent } from './components/weekly-system/weekly-system.component';
import { CommonModule } from '@angular/common';
import { TeamMeetingsComponent } from '../app/components/team-meetings/team-meetings.component';
import { ParentMeetingsComponent } from './components/parent-meetings/parent-meetings.component'
import { AuthGuardAdmin,AuthGuardParent,AuthGuardWorker } from './auth.guard';
import { LogInComponent } from './components/log-in/log-in.component';
import { WorkersComponent } from './components/workers/workers.component';

const routes: Routes = [
  {component:LogInComponent,path:""},
  {component:LogInComponent,path:"login"},
  {component:ParentMainComponent,path:"parent-main",canActivate:[AuthGuardParent],
   children:[
     {component:WelcomeComponent,path:""},
     {component:WeeklySystemComponent, path:"Calendar"}
   ]},
  {component:AdminMainComponent,path:"admin-main",canActivate:[AuthGuardAdmin],
  children:[
    {component:WelcomeComponent,path:""},
    {component:ChildrenComponent, path:"children"},
    {component:WorkersComponent, path:"professionals"},
    {component:WeeklySystemComponent, path:"weekly-system"},
    {component:TeamMeetingsComponent, path: "team-meetings"},
    {component: ParentMeetingsComponent,  path:"parent-meetings"},
    
  ]},
  {component:WorkerMainComponent, path:"worker-main",
  children:[
    {component:WelcomeComponent, path:""},
    {component:ChildrenComponent, path:"children"},
    {component:ParentMeetingsComponent, path:"parent-meetings"},
    {component:TeamMeetingsComponent, path:"team-meetings"}
  ]} 
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
  CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }

