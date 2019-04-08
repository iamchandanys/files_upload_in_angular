import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FileUploadFrameworkComponent } from './FileUpload/file-upload-framework/file-upload-framework.component';
import { ToLocalFolderFmComponent } from './FileUpload/file-upload-framework/to-local-folder-fm/to-local-folder-fm.component';
import { ToLocalFolderService } from './FileUpload/file-upload-framework/service/to-local-folder.service';

@NgModule({
  declarations: [
    AppComponent,
    FileUploadFrameworkComponent,
    ToLocalFolderFmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ToLocalFolderService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
