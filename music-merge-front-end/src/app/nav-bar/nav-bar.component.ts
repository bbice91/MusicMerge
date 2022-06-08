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
    // {
    //   route: "login",
    //   text: "Log In"
    // },
    {
      route: "artist-select",
      text: "Select Artist"
    },
    {
      route: "album-list-view",
      text: "Get Album Art"
    },
    {
      route: "neural-style-upload",
      text: "Generate Album Art with Custom Style"
    },
    {
      route: "generated-art-piece",
      text: "User Generated Albums"
    }
  ]

  ngOnInit(): void {
  }

}
