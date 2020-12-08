import { Component,ChangeDetectionStrategy,  ViewChild,  TemplateRef,OnInit}  from '@angular/core';
import {  startOfDay, endOfDay, subDays, addDays, endOfMonth, isSameDay, isSameMonth, addHours, addMinutes,} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalendarEvent, CalendarEventAction, CalendarEventTimesChangedEvent, CalendarView,} from 'angular-calendar';
import { CalanderService } from 'src/app/shared/services/calander.service';
import { Kind } from 'src/app/shared/models/kind';
import { AccountService } from 'src/app/shared/services/account.service';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';

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
  pink: {
    primary: '#ea1ea4',
    secondary: '#e789c7',
  }
};
@Component({
  selector: 'app-weekly-system-kg',
  templateUrl: './weekly-system-kg.component.html',
  styleUrls: ['./weekly-system-kg.component.scss']
})
export class WeeklySystemKgComponent implements OnInit {

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

  selectkng:string=null;

  kinderGardens:KinderGarden[];

  constructor(private modal: NgbModal,
    private calendarService:CalanderService
   ,private account:AccountService
   ,private kgService:KindergardenService) {}
  ngOnInit(): void {
    this.getKinderGardens();

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
    else if(  event.kindId==2 )
      event.color=colors.pink;
    else if(event.kindId==3)
      event.color=colors.blue;

    else 
      event.color=colors.red;
    
      event.end=new Date(event.end);
      event.start=new Date(event.start);
    });
  }
  getKinderGardens(){
    this.kgService.getKinderGardens().subscribe(res=>
      this.kinderGardens=res);
  }
  OnchangeGan() {
    if (this.selectkng != null)
      this.getEventsInKinderGarden(this.selectkng);

  }
  getEventsInKinderGarden(kng:string){
    let kinderGardenID=this.kinderGardens.find(kg=>kg.name==kng).id;
    this.calendarService.getKGardenCalender(kinderGardenID).subscribe
    (res=>
      {
        this.events=res;
        this.setColors();
        console.log(this.events);
      }
      );

  }
}
