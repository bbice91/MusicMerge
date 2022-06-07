
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
  vanGogh = new Option("{{5879}}")
  abstract = new Option("{{28059}}")
  mosaic = new Option("{{4719}}")
  trippy = new Option("{{2056}}")
  beads = new Option("{{37944}}")

  // Bob working on integrating NS to alter album image art, will update style Id's once complete

  reloadCurrentPage() {
    window.location.reload();
   }

  ngOnInit(): void {
  }

}
