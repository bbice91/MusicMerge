import { Component, OnInit } from '@angular/core';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { Album } from '../models/Album';
import { CoverartarchiveService } from '../cover-art-archive.service';
import { FormControl, FormGroup } from '@angular/forms';
import { CoverArtArchive } from '../models/CoverArtArchive';



@Component({
  selector: 'app-list-view',
  templateUrl: './album-list-view.component.html',
  styleUrls: ['./album-list-view.component.css']
})
export class AlbumListViewComponent {

  loading: boolean = false;
  mbid = new FormControl("");
  albumArt: CoverArtArchive = { image: "", largeImage: "" };

  constructor(private coverArtArchiveService: CoverartarchiveService) { }

  getAlbumArt(): void {
    const mbid = this.mbid.value;
    console.log(mbid); 
    this.coverArtArchiveService.getAlbumCoverArt(mbid).subscribe(
      response => { 
        console.log(response); 
        this.albumArt = response; 
        this.loading = false; 
      });
  }

}


