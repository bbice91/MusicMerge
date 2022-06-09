import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NeuralStyleUploadComponent } from './app/neural-style-upload/neural-style-upload.component';

@Injectable({
  providedIn: 'root'
})

export class NeuralStyleUploadService {

  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://musicmerge.azurewebsites.net/api/NeuralStyle";
  
  
  uploadAlbumWithStyle(photoUrl: string, styleID: number){
   
    return this.httpClient.post(`${this.baseUrl}/${photoUrl}/${photoUrl}`, NeuralStyleUploadComponent);
    }

}

// create moodels in front end for properties album info, etc. need from back end
