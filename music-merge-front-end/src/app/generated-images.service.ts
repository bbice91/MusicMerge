import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GeneratedImages } from './models/GeneratedImages';

@Injectable({
  providedIn: 'root'
})
export class GeneratedImagesService {

 
  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://localhost:5265/api/GeneratedImages";

  getGeneratedImage(){
    return this.httpClient.get<GeneratedImages>(this.baseUrl);
  }

  

}
