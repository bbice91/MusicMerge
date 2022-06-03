import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AlbumsService } from '../albums.service';
import { Album } from '../models/Album';
import { AlbumByArtist } from '../models/AlbumByArtist';
import { MusicBrainzService } from '../music-brainz.service';


@Component({
  selector: 'app-list-view',
  templateUrl: './album-list-view.component.html',
  styleUrls: ['./album-list-view.component.css']
})
export class AlbumListViewComponent implements OnInit {
  //albums$ = this._albumsByArtistService.getAlbums();

  albums: Album[] = [];


  constructor(private _albumsService: AlbumsService) { }


  ngOnInit(): void {
    this._albumsService.getAlbums().subscribe(albums => {
      this.albums = albums;
  })
}

}


