import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthLoginService {

  constructor(private _httpClient: HttpClient) { }
  baseUrl = "https://localhost:7265/authLogin"

}


 
  
 

  



