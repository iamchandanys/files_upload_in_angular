import { Component, OnInit } from '@angular/core';
import { HttpRequest, HttpClient, HttpEventType, HttpResponse } from '@angular/common/http';

import * as $ from 'jquery';
import { FileStatus } from '../models/file-status.model';

@Component({
  selector: 'app-to-local-folder-fm',
  templateUrl: './to-local-folder-fm.component.html',
  styleUrls: ['./to-local-folder-fm.component.sass']
})

export class ToLocalFolderFmComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  selectedFiles: File[] = [];
  progress: number;
  filesInProgress: string;
  fileStatus: FileStatus[] = [];

  ngOnInit() {
  }

  onFileChange(event) {
    this.selectedFiles = event.target.files;

    //To restrict user to upload only 5 files @ a time.
    if (this.selectedFiles.length <= 5) {
      //Do nothing...
    } else {
      this.selectedFiles = [];

      $(document).ready(function () {
        $('#FileUpload').val("");
      });

      window.alert("Only 5 files can be uploaded at a time.");
    }
  }

  UploadFile() {
    if (this.selectedFiles.length > 0) {

      for (let selFiles of this.selectedFiles) {
        this.filesInProgress = selFiles.name;

        const formData = new FormData();
        formData.append('UploadFile_' + selFiles.name, selFiles);

        const req = new HttpRequest('POST', 'http://localhost:50182/api/UploadFiles/UploadFilesToLocalFolder', formData, { reportProgress: true });

        this.httpClient.request(req).subscribe(
          (event: any) => {
            if (event.type === HttpEventType.UploadProgress) {
              // This is an upload progress event. Compute and show the % done.
              this.progress = Math.round(98 * event.loaded / event.total);
            } else if (event instanceof HttpResponse) {
              // Comes here only when the upload is completly done without any error.
              this.progress = 100;
              console.log('File is completely uploaded!');

              console.log(event);

              if (event.body)
                this.fileStatus.push(event.body);
            }
          },
          () => {

          },
          () => {
            // this.progress = 0;
          }
        )
      }

    } else {
      window.alert("Please select files to upload.");
    }
  }

}
