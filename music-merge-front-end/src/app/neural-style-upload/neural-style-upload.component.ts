//import { Component, OnInit } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { PostAlbums } from '../models/Album';
import { Router } from '@angular/router';

@Component({
  selector: 'app-album-upload',
  templateUrl: './neural-style-upload.component.html',
  styleUrls: ['./neural-style-upload.component.css']
})
export class NeuralStyleUploadComponent implements OnInit {

  constructor(private _albumsByArtistService: AlbumsByArtistService) { }
  

  neuralStyleFormGroup = new FormGroup({
    firstAlbumInput: new FormControl(''),
    styleInput: new FormControl(''),

  })

  uploadAlbumWithStyle(){
    
  }

  reloadCurrentPage() {
    window.location.reload();
   }

  ngOnInit(): void {
  }

}
