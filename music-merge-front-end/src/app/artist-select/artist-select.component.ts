import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Router } from '@angular/router';
import { AlbumByArtist, PostArtist } from '../models/AlbumByArtist';
import { Album } from '../models/Album';
import { CoverartarchiveService } from '../cover-art-archive.service';
import { CoverArtArchive } from '../models/CoverArtArchive';

@Component({
  selector: 'app-album-upload',
  templateUrl: './artist-select.component.html',
  styleUrls: ['./artist-select.component.css']
})
export class ArtistSelectComponent implements OnInit {
  loading: boolean = false;

  albums: AlbumByArtist[] = [];

  coverArts: CoverArtArchive[] = [];

  constructor(private _albumsByArtistService: AlbumsByArtistService, private _coverArtArchiveService: CoverartarchiveService) { }


  
  albumsByArtistFormGroup = new FormGroup({
    artistInput: new FormControl(""),
    albumArt: new FormControl(""),
  })


  requestAlbumsByArtist() {
    this.loading = true;
    const artist = this.albumsByArtistFormGroup.value.artistInput;
    this._albumsByArtistService.getAlbums(artist).subscribe(response => { console.log(response); this.albums = response; this.loading = false; });
  }

  getAlbumArt(){
    const mbid = this.albumsByArtistFormGroup.value.album.id;
    this._coverArtArchiveService.getAlbumCoverArt(mbid);
  }




  // reloadCurrentPage() {
  //   window.location.reload();
  //  }

  ngOnInit(): void {
  }
}

