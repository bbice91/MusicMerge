import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album, PostAlbums } from './models/Album';
import { AlbumByArtist } from './models/AlbumByArtist';
import { ArtistSelectComponent } from './artist-select/artist-select.component';
import { CoverArtArchive } from './models/CoverArtArchive';

@Injectable({
  providedIn: 'root'
})

export class AlbumsByArtistService {

  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://musicmerge.azurewebsites.net/api/MusicBrainz";
  
  
  getAlbums(artist: string){
    return this.httpClient.get<Array<CoverArtArchive>>(`${this.baseUrl}/${artist}`);
  }

}

// create moodels in front end for properties album info, etc. need from back end
