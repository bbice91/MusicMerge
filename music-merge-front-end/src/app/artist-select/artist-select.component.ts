import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist } from '../models/AlbumByArtist';
import { Album } from '../models/Album';
import { filter, from, map, switchMap, tap } from 'rxjs';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent implements OnInit {
  albums: Album[] = [];

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }
  

  albumsByArtistFormGroup = new FormGroup({
    artistInput: new FormControl(),

  })

  requestAlbumsByArtist() {
    var artistInput = this.albumsByArtistFormGroup.value.artistInput;
    this._albumsByArtistService.getAlbums(artistInput).subscribe(artistInput);

  }



  // reloadCurrentPage() {
  //   window.location.reload();
  //  }

  ngOnInit(): void {
    this._albumsByArtistService.getAlbums("artist").subscribe(albums => {
      this.albums = albums;
  })

}
}
