import { Component, OnDestroy, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist, PostArtist } from '../models/AlbumByArtist';
import { Album } from '../models/Album';
import { CoverartarchiveService } from '../cover-art-archive.service';
import { CoverArtArchive } from '../models/CoverArtArchive';
import { mergeMap, map, switchMap, Subject, Subscription } from 'rxjs';
import { pipe } from 'rxjs';
import { observable } from 'rxjs';
import { makeBindingParser } from '@angular/compiler';
import { AuthLoginService } from '../auth-login.service';


@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent implements OnInit {
  loading: boolean = false;

  albums: AlbumByArtist[] = [];

  artistInput = new FormControl("");

  requestAlbumInputSubject$ = new Subject<string>();
  requestAlbumsByArtist$ = this.requestAlbumInputSubject$.pipe(
    switchMap(artist => this._albumsByArtistService.getAlbums(artist))
  )

  constructor(
    private _albumsByArtistService: AlbumsByArtistService, 
    private _authService: AuthLoginService,
    private _router: Router
  ) { }



  ngOnInit(): void {
    const user = this._authService.tryGetUser();
    if(user) {
      this._authService.userName$.next(user);
    } else {
      this._router.navigate(['/', 'login']);
    }
  }

  requestAlbumsByArtist() {
    this.requestAlbumInputSubject$.next(this.artistInput.value)
  }

}

