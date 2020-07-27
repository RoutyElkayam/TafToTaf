import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertTeamMeetingComponent } from './insert-team-meeting.component';

describe('InsertTeamMeetingComponent', () => {
  let component: InsertTeamMeetingComponent;
  let fixture: ComponentFixture<InsertTeamMeetingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsertTeamMeetingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertTeamMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
