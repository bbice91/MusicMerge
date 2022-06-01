import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album, PostAlbums } from './models/Album';
import { AlbumByArtist } from './models/AlbumByArtist';
import { ArtistSelectComponent } from './artist-select/artist-select.component';

@Injectable({
  providedIn: 'root'
})

export class AlbumsByArtistService {

  constructor(private httpClient: HttpClient) { }
  baseUrl = "http://localhost:5265/api/MusicBrainz/";

  
  getAlbums(artist: string){
   
    return this.httpClient.get<Array<AlbumByArtist>>(`${this.baseUrl}/${artist}`);
  }

}

// create moodels in front end for properties album info, etc. need from back end
