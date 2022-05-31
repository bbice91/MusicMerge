import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlbumByArtist } from './models/AlbumByArtist';
@Injectable({
  providedIn: 'root'
})
export class MusicBrainzService {

  constructor(private httpClient: HttpClient) { }

  baseUrl = "http://localhost:5265/api/MusicBrainz/";

  getAlbumsByArtist(){
    return this.httpClient.get<Array<AlbumByArtist>>(this.baseUrl);


  }


}
