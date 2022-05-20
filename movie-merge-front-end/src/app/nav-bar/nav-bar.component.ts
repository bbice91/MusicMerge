import { Component, OnInit } from "@angular/core";


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor() { }
  public routes = [
    {
      route: "home",
      text: "Home"
    },
    {
      route: "album-upload",
      text: "Upload Albums"
    },
    {
      route: "contact",
      text: "Account Info"
    },


  ]

  ngOnInit(): void {
  }

}
