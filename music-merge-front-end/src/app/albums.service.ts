import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album, PostAlbums } from './models/Album';
import { AlbumsByArtistService } from './albums-by-artist.service';
import { ArtistSelectComponent } from './artist-select/artist-select.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AlbumsService {

  add_header: 'Access-Control-Allow-Origin' | undefined;

  constructor(private httpClient: HttpClient) { 
  }
   baseUrl = "https://musicmerge.azurewebsites.net/api/Albums";

    getAlbums(){
   
     return this.httpClient.get<Array<Album>>(`${this.baseUrl}`);
     }



}

// create moodels in front end for properties album info, etc. need from back end
