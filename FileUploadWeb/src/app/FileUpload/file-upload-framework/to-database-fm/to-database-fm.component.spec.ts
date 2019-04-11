import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDatabaseFmComponent } from './to-database-fm.component';

describe('ToDatabaseFmComponent', () => {
  let component: ToDatabaseFmComponent;
  let fixture: ComponentFixture<ToDatabaseFmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToDatabaseFmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToDatabaseFmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
