import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FileUploader } from 'ng2-file-upload';

const UploadURL = 'https://localhost:44332/api/file';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})

export class UploadFileComponent implements OnInit {


  constructor(private http: HttpClient) { }

  public uploader: FileUploader = new FileUploader({url: UploadURL, itemAlias: 'photo'});


  ngOnInit() {    
    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };
    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
         console.log('FileUpload:uploaded:', item, status, response);
         const parsedResponse = JSON.parse(response);
         alert('File uploaded successfully ' + parsedResponse.fileName);
     };
  }

  
}
