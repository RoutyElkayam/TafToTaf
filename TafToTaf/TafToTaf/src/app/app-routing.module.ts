import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { ChildrenComponent } from './components/children/children.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = [
  {component:LogInComponent,path:""},
  {component:ParentMainComponent,path:"parent-main",canActivate:[AuthGuard]},
  {component:AdminMainComponent,path:"admin-main",canActivate:[AuthGuard],children:[
     {component:ChildrenComponent, path:"children"}
  ]},
  {component:WorkerMainComponent, path:"worker-main",canActivate:[AuthGuard]},
  {component:WelcomeComponent, path:"welcome"},
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

