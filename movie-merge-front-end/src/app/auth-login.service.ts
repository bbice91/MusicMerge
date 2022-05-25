import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, Subject } from 'rxjs';
import { User } from './user';
import {v4 as uuidv4 } from 'uuid';

 @Injectable({
   providedIn: 'root'
 })
export class AuthLoginService {

 constructor( private _http: HttpClient) { }
  baseUrl = "https://localhost:7265/authLogin"

  userName$: ReplaySubject<User | null> = new ReplaySubject();

  setUserName(userName : User | null) {
    this.userName$.next(userName);
  }

  redirectSpotifyToken(){
    const authState = uuidv4();
    localStorage.setItem("authState", authState);

    const queryParameters = [
      'client_id=6d95cb05880c44d4aba9865140cc7bfa',
      'state=${authState}',
      'client_secret=e49fcbb75d1849f6bf638b908c1ade75',
      encodeURIComponent('redirect_uri=https://localhost:7265/authLogin'),
    ];

    window.location.href = `https://accounts.spotify.com/authorize?$(queryParameters.join('&'))`;
  }

  spotifylogin(userName: string) {
    return this._http.get<User>(`${this.baseUrl}/login/${userName}/Spotify`)

  }




  

}
  
