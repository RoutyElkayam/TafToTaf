import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentMeetingsComponent } from './parent-meetings.component';

describe('ParentMeetingsComponent', () => {
  let component: ParentMeetingsComponent;
  let fixture: ComponentFixture<ParentMeetingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParentMeetingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParentMeetingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
