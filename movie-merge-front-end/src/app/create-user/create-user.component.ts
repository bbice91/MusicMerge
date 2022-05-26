import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Users } from '../models/Users';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  userName: any;

  //constructor(private _createUser: UsersService) { }
  constructor(router: Router, _usersService: UsersService, httpClient: HttpClient) { }

  createUserFormGroup = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),

  })
//   CreateUserName(userName: Users, password: Users) {
//      const createUserName: CreateUserName = this.createUserFormGroup.value;
//     this.userName.createUserName(createUserName).subscribe();
//  }



  ngOnInit(): void {
  }

}
