import { Component, OnInit } from '@angular/core';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Album } from '../models/Album';

@Component({
  selector: 'app-list-view',
  templateUrl: './album-list-view.component.html',
  styleUrls: ['./album-list-view.component.css']
})
export class AlbumListViewComponent implements OnInit {
  albums$ = this._albumsByArtistService.getAlbums("artist");

  albums: Album[] = [];


  constructor(private _albumsByArtistService: AlbumsByArtistService) { }

  ngOnInit(): void {
    this._albumsByArtistService.getAlbums("artist").subscribe(albums => {
      this.albums = albums;
  })
}

}


