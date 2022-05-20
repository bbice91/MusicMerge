//import { Component, OnInit } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsService } from '../albums.service';
import { PostAlbums } from '../models/Albums';

@Component({
  selector: 'app-album-upload',
  templateUrl: './album-upload.component.html',
  styleUrls: ['./album-upload.component.css']
})
export class AlbumUploadComponent implements OnInit {

  constructor(private _albumsService: AlbumsService) { }
  

  albumsFormGroup = new FormGroup({
    albumOneInput: new FormControl(''),
    albumTwoInput: new FormControl(''),

  })

  submitAlbums() {
    const postAlbums: PostAlbums = this.albumsFormGroup.value;
    // this._albumsService.postAlbums(postAlbums).subscribe();
  }

  reloadCurrentPage() {
    window.location.reload();
   }

  ngOnInit(): void {
  }

}
