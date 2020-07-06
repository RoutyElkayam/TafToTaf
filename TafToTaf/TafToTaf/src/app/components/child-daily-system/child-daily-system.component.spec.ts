import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildDailySystemComponent } from './child-daily-system.component';

describe('ChildDailySystemComponent', () => {
  let component: ChildDailySystemComponent;
  let fixture: ComponentFixture<ChildDailySystemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildDailySystemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildDailySystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
