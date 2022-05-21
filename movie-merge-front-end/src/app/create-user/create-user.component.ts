import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  constructor(private _createUser: UsersService) { }

  createUserFormGroup = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),

  })

  ngOnInit(): void {
  }

}
