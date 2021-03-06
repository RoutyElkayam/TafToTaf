import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { ParentMainComponent } from './components/parent-main/parent-main.component';
import { WorkerMainComponent } from './components/worker-main/worker-main.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavAdminComponent } from './components/nav-admin/nav-admin.component';
import { NavParentComponent } from './components/nav-parent/nav-parent.component';
import { NavWorkerComponent } from './components/nav-worker/nav-worker.component';
import { ChildMedicalFileComponent } from './components/child-medical-file/child-medical-file.component';
import { ChildDailySystemComponent } from './components/child-daily-system/child-daily-system.component';
import { ChildrenComponent } from './components/children/children.component';
import { TeamMeetingsComponent } from './components/team-meetings/team-meetings.component';
import { ParentMeetingsComponent } from './components/parent-meetings/parent-meetings.component';
import { WeeklySystemComponent } from './components/weekly-system/weekly-system.component';
import { MonthlySystemComponent } from './components/monthly-system/monthly-system.component';
import { ChildComponent } from './components/child/child.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { InsertChildComponent } from './components/insert-child/insert-child.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { CommonModule } from '@angular/common';
import { FlatpickrModule } from 'angularx-flatpickr';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { InsertTeamMeetingComponent } from './components/insert-team-meeting/insert-team-meeting.component';
import { ModalDeleteComponent } from './components/modal-delete/modal-delete.component';
import { AuInterceptor } from './au.interceptor';
import { EditChildComponent } from './components/edit-child/edit-child.component';
import { WorkersComponent } from './components/workers/workers.component';
import { InsertWorkerComponent } from './components/insert-worker/insert-worker.component';
import { EditWorkerComponent } from './components/edit-worker/edit-worker.component';
import { DeleteWorkerComponent } from './components/delete-worker/delete-worker.component';
import { LoaderComponent } from './components/loader/loader.component';
import { ReportChildComponent } from './components/report-child/report-child.component';
import { ChildWorkerComponent } from './components/child-worker/child-worker.component';
import { AdminCalendarComponent } from './components/admin-calendar/admin-calendar.component';
import { WeeklySystemKgComponent } from './components/weekly-system-kg/weekly-system-kg.component';

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
    WeeklySystemComponent,
    MonthlySystemComponent,
    ChildComponent,
    WelcomeComponent,
    InsertChildComponent,
    InsertTeamMeetingComponent,
    ModalDeleteComponent,
    EditChildComponent,
    WorkersComponent,
    InsertWorkerComponent,
    EditWorkerComponent,
    DeleteWorkerComponent,
    LoaderComponent,
    ReportChildComponent,
    ChildWorkerComponent,
    AdminCalendarComponent,
    WeeklySystemKgComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    CommonModule,
    NgbModalModule,
    FlatpickrModule.forRoot(), 
    NgbModule, 

   
    
  ],
  entryComponents:[InsertChildComponent, ModalDeleteComponent,EditChildComponent,EditWorkerComponent
  ,DeleteWorkerComponent,InsertWorkerComponent],
  providers:
   [
     NgbActiveModal,
     {provide: HTTP_INTERCEPTORS,
      useClass: AuInterceptor,
      multi: true }
    ],
  bootstrap: [AppComponent],
})
export class AppModule { }
