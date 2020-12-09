import { Component,ChangeDetectionStrategy,  ViewChild,  TemplateRef,OnInit}  from '@angular/core';
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
  pink: {
    primary: '#ea1ea4',
    secondary: '#e789c7',
  }
};
@Component({
  selector: 'app-weekly-system',
  templateUrl: './weekly-system.component.html',
  styleUrls: ['./weekly-system.component.scss']
})
export class WeeklySystemComponent implements OnInit  {
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
  //  =[ {
  //     start: addHours(startOfDay(new Date()), 9),
  //     end: addMinutes(new Date(), 45),
  //     title: 'קלינאית תקשורת:נירית ילד:שיר גולדשטיין',
  //     color: colors.yellow,
  //   },
  //   {
  //     start: addHours(startOfDay(new Date()), 9),
  //     end: addMinutes(new Date(), 45),
  //     title: 'קלינאית תקשורת :נירית ילד: נועם כחלון',
  //     color: colors.yellow,
  //   },
  //   {
  //     start: subDays(endOfMonth(new Date()), 3),
  //     end: addDays(endOfMonth(new Date()), 3),
  //     title: 'A long event that spans 2 months',
  //     color: colors.yellow,
  //   },
  //   {
  //     start: addHours(startOfDay(new Date()), 2),
  //     end: addHours(new Date(), 2),
  //     title: 'פיזיותרפיה:אלינוי ילדה: חן שמחה עזראן',
  //     color: colors.yellow,
  //   },
  // ];

  activeDayIsOpen: boolean = true;

  constructor(private modal: NgbModal,
    private calendarService:CalanderService
   ,private account:AccountService) {}
  ngOnInit(): void {
    if(this.account.currentUser.kindUser==2)
    {
      
      this.calendarService.getWorkerCalender(this.account.userProffesional.id).subscribe(
      res=>{this.events=res;console.log(this.events);
        this.setColors()});
    }
    else if(this.account.currentUser.kindUser==3)
    {    
      this.calendarService.getChildCalender(this.account.userChild.id).subscribe(
      res=>{this.events=res;console.log(this.events);
        this.setColors();}
    );
    }

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

}
