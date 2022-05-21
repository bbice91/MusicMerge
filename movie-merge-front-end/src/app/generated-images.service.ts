import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GeneratedImagesService {

 
  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://localhost:7265/generated-images";
}
