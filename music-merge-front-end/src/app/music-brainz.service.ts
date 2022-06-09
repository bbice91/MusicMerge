import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlbumByArtist } from './models/AlbumByArtist';

@Injectable({
  providedIn: 'root'
})
export class MusicBrainzService {

  constructor(private httpClient: HttpClient) { }

  baseUrl = "https://musicmerge.azurewebsites.net/api/MusicBrainz/{artist}";

  getAlbumsByArtist(){
    return this.httpClient.get<Array<AlbumByArtist>>(this.baseUrl);


  }


}
