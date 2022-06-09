import { AfterViewInit, Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router, Routes } from "@angular/router";
import { AuthLoginService } from "../auth-login.service";


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements AfterViewInit {


  constructor(private _authService: AuthLoginService, private _router: Router) { }
  ngAfterViewInit(): void {
    setTimeout(() => {
      if (!this._router.url.includes("code")) {
        const user = this._authService.tryGetUser();
        if (user) {
          this._authService.user$.next(user);
        } else {
          this._router.navigate(['/', 'login']);
        }
      }
    }, 1000);
  }

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
      route: "neural-style-upload",
      text: "Generate Album Art with Custom Style"
    },
    {
      route: "generated-art-piece",
      text: "User Generated Albums"
    }
  ]

}
