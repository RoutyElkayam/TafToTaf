import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { ChildrenComponent } from './components/children/children.component';
import { WelcomeComponent } from './components/welcome/welcome.component';



const routes: Routes = [
  {component:LogInComponent,path:""},
  {component:ParentMainComponent,path:"parent-main"},
  {component:AdminMainComponent,path:"admin-main",children:[
     {component:ChildrenComponent, path:"children"}
  ]},
  {component:WorkerMainComponent, path:"worker-main"},
  {component:WelcomeComponent, path:"welcome"},
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

