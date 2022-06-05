import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist, PostArtist } from '../models/AlbumByArtist';
import { Album } from '../models/Album';

@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent implements OnInit {
  loading: boolean = false;

  albums: AlbumByArtist[] = [];

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }


  
  albumsByArtistFormGroup = new FormGroup({
    artistInput: new FormControl(""),
    albumArt: new FormControl(""),
  })


  requestAlbumsByArtist() {
    this.loading = true;
    const artist = this.albumsByArtistFormGroup.value.artistInput;
    this._albumsByArtistService.getAlbums(artist).subscribe(response => { console.log(response); this.albums = response; this.loading = false; });
  }




  // reloadCurrentPage() {
  //   window.location.reload();
  //  }

  ngOnInit(): void {
  }
}

