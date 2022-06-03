import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album, PostAlbums } from './models/Album';
import { AlbumByArtist } from './models/AlbumByArtist';
import { ArtistSelectComponent } from './artist-select/artist-select.component';
import { from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AlbumsByArtistService {


  constructor(private httpClient: HttpClient) { 
  
   }
   baseUrl = "https://localhost:5265/api/MusicBrainz";
  
  getAlbums(artist: string) {


    // return from(fetch(`${this.baseUrl}/${artist}`, {
    //   credentials: "include"
    // }));

    // const artistRequest = new HttpRequest("GET",`${this.baseUrl}/${artist}`, {
    //   headers: new HttpHeaders({
    //     "Credentials": "include"
    //   })
    // })
    // return this.httpClient.request<Array<AlbumByArtist>>(artistRequest)
      return this.httpClient.get<Array<AlbumByArtist>>(`${this.baseUrl}/${artist}`, {withCredentials: true});
    }

}

// create moodels in front end for properties album info, etc. need from back end
