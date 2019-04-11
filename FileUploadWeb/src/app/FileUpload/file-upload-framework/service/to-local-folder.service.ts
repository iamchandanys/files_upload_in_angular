import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ToLocalFolderService {

  constructor(private httpClient: HttpClient) { }

  DownloadFilesFromLocalFolder(FilePath: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: 'response' as 'body',
      responseType: 'blob' as 'blob'
    };

    return this.httpClient.get("http://localhost:50182/api/UploadFiles/DownloadFilesFromLocalFolder?FilePath=" + FilePath, httpOptions);
  }

  DownloadFilesFromDatabase(Id: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: 'response' as 'body',
      responseType: 'blob' as 'blob'
    };

    return this.httpClient.get("http://localhost:50182/api/UploadFiles/DownloadFilesFromDatabase?Id=" + Id, httpOptions);
  }
  
}
