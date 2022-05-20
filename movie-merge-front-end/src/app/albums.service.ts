import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Albums, PostAlbums } from './models/Albums';

@Injectable({
  providedIn: 'root'
})

export class AlbumsService {
  
  postAlbums(postAlbums: PostAlbums) {
    throw new Error('Method not implemented.');
  }

  constructor(private httpClient: HttpClient) { }
  baseUrl = "https://localhost:7265/swagger/index.html";

  uploadAlbum(albums: PostAlbums) {
    return this.httpClient.post<Albums>(this.baseUrl, albums);
  }
}

// create moodels in front end for properties album info, etc. need from back end
