import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToLocalFolderFmComponent } from './to-local-folder-fm.component';

describe('ToLocalFolderFmComponent', () => {
  let component: ToLocalFolderFmComponent;
  let fixture: ComponentFixture<ToLocalFolderFmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToLocalFolderFmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToLocalFolderFmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
