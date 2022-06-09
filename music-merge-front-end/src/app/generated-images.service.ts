import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GeneratedArtInProcess } from './models/GeneratedArtInProcess';
import { GeneratedArtProgress } from './models/GeneratedArtProgress';

@Injectable({
  providedIn: 'root'
})
export class GeneratedImagesService {

 
  constructor(private httpClient: HttpClient) { }
  baseUrl = "http://localhost:5265/api/NeuralStyle";

  generateArt(photo_url: string, style_id: number) :Observable<GeneratedArtInProcess>{
    const resp = this.httpClient.get<GeneratedArtInProcess>(`${this.baseUrl}/generateArt?photo_url=${photo_url}&style_id=${style_id}`);
    console.log(resp);
    return resp;
  }

  getGeneratedImage(submission_id: string) :Observable<GeneratedArtProgress>{
    return this.httpClient.get<GeneratedArtProgress>(`${this.baseUrl}/getGeneratedArt/${submission_id}`);
  }

  

}
