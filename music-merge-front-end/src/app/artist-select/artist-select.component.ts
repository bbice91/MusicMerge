import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  albums: Album[] = [];

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }
  

  albumsByArtistFormGroup = new FormGroup({
    artistInput: new FormControl(""),
    

  })

  requestAlbumsByArtist() {
    const logForCors = this.albumsByArtistFormGroup.value.artistInput;
    console.log(logForCors)
    this._albumsByArtistService.getAlbums(logForCors).subscribe(response => console.log(response));

    
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

