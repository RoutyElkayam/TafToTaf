import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertChildComponent } from './insert-child.component';

describe('InsertChildComponent', () => {
  let component: InsertChildComponent;
  let fixture: ComponentFixture<InsertChildComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsertChildComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
