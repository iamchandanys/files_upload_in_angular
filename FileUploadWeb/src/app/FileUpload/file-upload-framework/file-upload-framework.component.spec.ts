import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileUploadFrameworkComponent } from './file-upload-framework.component';

describe('FileUploadFrameworkComponent', () => {
  let component: FileUploadFrameworkComponent;
  let fixture: ComponentFixture<FileUploadFrameworkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileUploadFrameworkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileUploadFrameworkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
