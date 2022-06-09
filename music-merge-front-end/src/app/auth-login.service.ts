import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject, Subject } from 'rxjs';
import { User } from './models/User';
import { v4 as uuidv4 } from 'uuid';
import { user } from './user';
import { observeNotification } from 'rxjs/internal/Notification';

@Injectable({
  providedIn: 'root'
})
export class AuthLoginService {

  constructor(private _http: HttpClient) { }
  baseUrl = "https://musicmerge.azurewebsites.net/api/oauth"

  user$: ReplaySubject<User | null> = new ReplaySubject();

  tryGetUser(): null | User {
    const user: string | null = localStorage.getItem("user");
    if (user) {
      return JSON.parse(user);
    }

    return null
  }

  setUserName(userName: User | null) {
    this.user$.next(userName);
  }

  authorizeSpotifyToken(authCode: string) {

    const queryParameters = [
      'client_id=be3700051b734c8c8cff0857f4e0f60d',
      'client_secret=7cd175eca3b4ef88b93601f7e08c75e',
      'redirect_uri=https://musicmerge.azurewebsites.net/login',
      'response_type=code'
    ];

    window.location.href = `https://accounts.spotify.com/authorize?${queryParameters.join('&')}`;

  }

  redirectSpotifyToken() {
    const queryParameters = [
      'client_id=be3700051b734c8c8cff0857f4e0f60d',
      'redirect_uri=https://musicmerge.azurewebsites.net/login',
      'response_type=code'
    ];

    window.location.href = `https://accounts.spotify.com/authorize?${queryParameters.join('&')}`;
  }


  spotifylogin(code: string) {
    return this._http.get<User>(`${this.baseUrl}/login/${code}`)
  }

  autoLogin(id: number) {
    return this._http.get<User>(`${this.baseUrl}/auto-login/${id}`);
  }

  logout(id: number) {
    return this._http.get(`${this.baseUrl}/logout/${id}`);
  }
}

