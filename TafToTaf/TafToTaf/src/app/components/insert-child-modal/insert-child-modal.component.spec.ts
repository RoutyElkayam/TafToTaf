import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertChildModalComponent } from './insert-child-modal.component';

describe('InsertChildModalComponent', () => {
  let component: InsertChildModalComponent;
  let fixture: ComponentFixture<InsertChildModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsertChildModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertChildModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
