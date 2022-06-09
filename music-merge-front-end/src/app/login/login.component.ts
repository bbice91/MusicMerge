import { Component, Input, OnInit } from '@angular/core';
import { map, tap } from 'rxjs';
import { filter } from 'rxjs';
import { switchMap } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthLoginService } from '../auth-login.service';
import { user } from '../user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _authLoginService: AuthLoginService, 
    private _router: Router
  ) {}

  @Input() danceImg ="https://image.shutterstock.com/image-vector/group-young-happy-dancing-people-260nw-1203116578.jpg"

  onSpotifyLogin(){
    this._authLoginService.redirectSpotifyToken();
  }
 

  ngOnInit(): void { 

    this._activatedRoute.queryParams.pipe(
      map(params => ({code: params["code"]})),
      filter(p => p.code),
      switchMap((p: {code: string}) => this._authLoginService.spotifylogin(p.code))
    ) 
    .subscribe(userName => {
      localStorage.setItem("UserName", JSON.stringify(userName));
      this._authLoginService.setUserName(userName);
      this._router.navigate(["/"]);
    });
  }

  

}

// The first step is to send a POST request to the /api/token endpoint of the Spotify OAuth 2.0 Service with the following parameters encoded in application/x-www-form-urlencoded:

// REQUEST BODY PARAMETER	VALUE
// grant_type	Required
// Set it to client_credentials.
// The headers of the request must contain the following parameters:

// HEADER PARAMETER	VALUE
// Authorization	Required
// Base 64 encoded string that contains the client ID and client secret key. The field must have the format: Authorization: Basic <base64 encoded client_id:client_secret>
// Content-Type	Required
// Set to application/x-www-form-urlencoded.
