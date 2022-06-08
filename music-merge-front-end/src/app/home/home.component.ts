import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }


  @Input() music = "https://img.freepik.com/free-vector/musical-notes-frame-with-text-space_1017-32857.jpg?w=2000"
  



  ngOnInit(): void {

  }

}
