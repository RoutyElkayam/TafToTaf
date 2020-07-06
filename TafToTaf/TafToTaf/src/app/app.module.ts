import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AccordionModule} from 'primeng/accordion';     //accordion and accordion tab
import {MenuItem} from 'primeng/api';
import { NavAdminComponent } from './components/nav-admin/nav-admin.component';
import { NavParentComponent } from './components/nav-parent/nav-parent.component';
import { NavWorkerComponent } from './components/nav-worker/nav-worker.component';
import { ChildMedicalFileComponent } from './components/child-medical-file/child-medical-file.component';
import { ChildDailySystemComponent } from './components/child-daily-system/child-daily-system.component';
import { ChildrenComponent } from './components/children/children.component';
import { TeamMeetingsComponent } from './components/team-meetings/team-meetings.component';
import { ParentMeetingsComponent } from './components/parent-meetings/parent-meetings.component';
import { DailySystemComponent } from './components/daily-system/daily-system.component';
import { WeeklySystemComponent } from './components/weekly-system/weekly-system.component';
import { MonthlySystemComponent } from './components/monthly-system/monthly-system.component';
import { ChildComponent } from './components/child/child.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { InsertChildComponent } from './components/insert-child/insert-child.component';

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    ParentMainComponent,
    WorkerMainComponent,
    AdminMainComponent,
    NavAdminComponent,
    NavParentComponent,
    NavWorkerComponent,
    ChildMedicalFileComponent,
    ChildDailySystemComponent,
    ChildrenComponent,
    TeamMeetingsComponent,
    ParentMeetingsComponent,
    DailySystemComponent,
    WeeklySystemComponent,
    MonthlySystemComponent,
    ChildComponent,
    WelcomeComponent,
    InsertChildComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AccordionModule,
  

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
