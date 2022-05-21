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
      route: "login",
      text: "Log In"
    },
    {
      route: "create-user",
      text: "Create An Account"
    },
    {
      route: "generated-art-piece",
      text: "Generate Album Art"
    },
    {
      route: "album-upload",
      text: "Upload Albums"
    },



  ]

  ngOnInit(): void {
  }

}
