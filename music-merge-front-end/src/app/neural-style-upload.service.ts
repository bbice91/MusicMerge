import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album, PostAlbums } from './models/Album';
import { AlbumByArtist } from './models/AlbumByArtist';
import { ArtistSelectComponent } from './artist-select/artist-select.component';
import { GeneratedArtInProcess } from './response-models/generated-art-in-process';
import { KeyValuePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class NeuralStyleUploadService {

  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://neuralstyle.art/api.json";  
  
  generateArt(photo_url: string, styleId: number){
   
    return this.httpClient.get<Array<GeneratedArtInProcess>>(`${this.baseUrl}/${photo_url}/${styleId}`);
    }   

}

