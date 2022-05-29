import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './models/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {



  constructor(router: Router, _usersService: UsersService, httpClient: HttpClient) { }
  baseUrl = "https://localhost:5265/api/users";

  // CreateUser(userName: Users, password: Users) {
  //   return this.httpClient.post<Users>(this.baseUrl, userName, password);
  // }
}






