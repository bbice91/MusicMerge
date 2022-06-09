import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { DeepArtStyle } from './models/DeepArtStyle';
import { GeneratedArtInProcess } from './models/GeneratedArtInProcess';
import { GeneratedArtProgress } from './models/GeneratedArtProgress';

@Injectable({
  providedIn: 'root'
})
export class GeneratedImagesService {


  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://musicmerge.azurewebsites.net/api/NeuralStyle";

  generateArt(photo_url: string, style_id: number) :Observable<GeneratedArtInProcess>{
    const resp = this.httpClient.get<GeneratedArtInProcess>(`${this.baseUrl}/generateArt?photo_url=${photo_url}&style_id=${style_id}`);
    console.log(resp);
    return resp;
  }

  getGeneratedImage(submission_id: string, user_id: number) :Observable<GeneratedArtProgress>{
    return this.httpClient.get<GeneratedArtProgress>(`${this.baseUrl}/getGeneratedArt/${submission_id}/${user_id}`);
  }

  getStyles() : Observable<Array<DeepArtStyle>>{ 
    return this.httpClient.get<Array<DeepArtStyle>>(this.baseUrl);
  }

  getImagesById(id: number): Observable<Array<string>> {
    return this.httpClient.get<Array<string>>(`${this.baseUrl}/getImagesById/${id}`);
  }

}
