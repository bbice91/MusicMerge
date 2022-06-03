
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { PostAlbums } from '../models/Album';
import { Router } from '@angular/router';
import { NeuralStyleUploadService } from '../neural-style-upload.service';

@Component({
  selector: 'app-neural-style-upload',
  templateUrl: './neural-style-upload.component.html',
  styleUrls: ['./neural-style-upload.component.css']
})
export class NeuralStyleUploadComponent implements OnInit {

  constructor(private _neuralStyleUploadService: NeuralStyleUploadService) {

   }
  

  neuralStyleFormGroup = new FormGroup({
    photo_url: new FormControl(),
    styleId: new FormControl(),

  })
  uploadAlbumWithStyle (){
    var photo_url = this.neuralStyleFormGroup.value.photo_url;
    var styleId = this.neuralStyleFormGroup.value.styleId;
    this._neuralStyleUploadService.generateArt(photo_url, styleId).subscribe(response => console.log(response));
  }

  reloadCurrentPage() {
    window.location.reload();
   }

  ngOnInit(): void {
  }



}
