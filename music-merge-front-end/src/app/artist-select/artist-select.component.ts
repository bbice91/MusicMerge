import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist, PostArtist } from '../models/AlbumByArtist';
import { Album } from '../models/Album';
import { CoverartarchiveService } from '../cover-art-archive.service';
import { CoverArtArchive } from '../models/CoverArtArchive';
import { mergeMap, map, switchMap } from 'rxjs';
import { pipe } from 'rxjs';
import { observable } from 'rxjs';
import { makeBindingParser } from '@angular/compiler';


@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent {
  loading: boolean = false;

  albums: AlbumByArtist[] = [];

  artistInput = new FormControl("");

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }

  requestAlbumsByArtist() {
    this.loading = true;
    const artist = this.artistInput.value;
    console.log(artist); 
    this._albumsByArtistService.getAlbums(artist).subscribe(
      response => { 
        console.log(response); 
        this.albums = response; 
        this.loading = false; 
      });
  }

}

