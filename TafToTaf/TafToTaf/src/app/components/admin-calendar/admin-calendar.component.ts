import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import {  startOfDay, endOfDay, subDays, addDays, endOfMonth, isSameDay, isSameMonth, addHours, addMinutes,} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarEventAction, CalendarEventTimesChangedEvent, CalendarView,} from 'angular-calendar';
import { CalanderService } from 'src/app/shared/services/calander.service';
import { Kind } from 'src/app/shared/models/kind';
import { AccountService } from 'src/app/shared/services/account.service';
const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};
@Component({
  selector: 'app-admin-calendar',
  templateUrl: './admin-calendar.component.html',
  styleUrls: ['./admin-calendar.component.scss']
})
export class AdminCalendarComponent implements OnInit {

  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;
  view: CalendarView = CalendarView.Month;
  CalendarView = CalendarView;
  viewDate: Date = new Date();
  modalData: {
    action: string;
    event: CalendarEvent;
  };
  refresh: Subject<any> = new Subject();
  events: CalendarEvent[] ;
  activeDayIsOpen: boolean = true;
  kinderGardens:KinderGarden[];
  selectedKng:KinderGarden=null;
  constructor(private modal: NgbModal,
    private calendarService:CalanderService
   ,private account:AccountService
   ,private kinderGardenService:KindergardenService) {}


  ngOnInit(): void {

    }


  getKinderGardens(): void {
    this.kinderGardenService.getKinderGardens()
      .subscribe(kinderGardens => { this.kinderGardens = kinderGardens, console.log(this.kinderGardens) });
  }


  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  handleEvent(action: string, event: CalendarEvent): void {
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }
  setColors(){
    this.events.forEach(event => {
    if(event.kindId==1)
      event.color=colors.yellow;
    else if(event.kindId==2)
      event.color=colors.red;
    else 
      event.color=colors.blue;   
      event.end=new Date(event.end);
      event.start=new Date(event.start);
    });
  }
  OnchangeGan() {
    if (this.selectedKng != null)
      this.getCalendarOfKinderGarden();

  }
  getCalendarOfKinderGarden() {
   
    this.calendarService.getKGardenCalender(this.selectedKng.id).subscribe(
      res=>{this.events=res,
        this.setColors();}
    );
  }
}
