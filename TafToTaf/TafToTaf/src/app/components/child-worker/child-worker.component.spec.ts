import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildWorkerComponent } from './child-worker.component';

describe('ChildWorkerComponent', () => {
  let component: ChildWorkerComponent;
  let fixture: ComponentFixture<ChildWorkerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildWorkerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildWorkerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
