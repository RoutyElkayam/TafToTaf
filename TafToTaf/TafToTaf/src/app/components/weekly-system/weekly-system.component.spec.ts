import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklySystemComponent } from './weekly-system.component';

describe('WeeklySystemComponent', () => {
  let component: WeeklySystemComponent;
  let fixture: ComponentFixture<WeeklySystemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeeklySystemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeeklySystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
