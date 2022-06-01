import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist } from '../models/AlbumByArtist';

@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent implements OnInit {

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }
  

  albumsByArtistFormGroup = new FormGroup({
    artistInput: new FormControl(''),

  })

  requestAlbumsByArtist() {
    const postArtist: AlbumByArtist = this.albumsByArtistFormGroup.value;
    this._albumsByArtistService.getAlbums("artist").subscribe();
  }

  reloadCurrentPage() {
    window.location.reload();
   }

  ngOnInit(): void {
  }

}
