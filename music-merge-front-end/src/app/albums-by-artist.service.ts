import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AlbumByArtist } from './models/AlbumByArtist';

@Injectable({
  providedIn: 'root'
})
export class AlbumsByArtistService {
  //  headers: {
  //    'Content-Type': 'application/json';
  //    Accept: 'application/json';
  //  } | any

  constructor(private httpClient: HttpClient) { }
  

  baseUrl = "https://localhost:5265/api/MusicBrainz/";



  
  
    getAlbums(artist: string){
   
     return this.httpClient.get<Array<AlbumByArtist>>(`${this.baseUrl}/${artist}`);
     }

}
