
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { PostAlbums } from '../models/Album';
import { Router } from '@angular/router';
import { GeneratedImagesService } from '../generated-images.service';
import { GeneratedArtProgress } from '../models/GeneratedArtProgress';
import { debounceTime, delay, switchMap } from 'rxjs';

@Component({
  selector: 'app-album-upload',
  templateUrl: './neural-style-upload.component.html',
  styleUrls: ['./neural-style-upload.component.css']
})
export class NeuralStyleUploadComponent implements OnInit {

  albumUrlInput = new FormControl('');
  styleInput = new FormControl('');
  loading: boolean = false;
  generatedArtProgress: GeneratedArtProgress = { status: "", url:"" };

  constructor(private generatedImagesService: GeneratedImagesService) { }

  reloadCurrentPage() {
    window.location.reload();
  }

  ngOnInit(): void {
  }

  generateArt(): void {
    this.loading = true;
    const photo_url = this.albumUrlInput.value;
    const style_id = this.styleInput.value;
    this.generatedImagesService.generateArt(photo_url, style_id).pipe(
        delay(5000),
        switchMap(resp => this.generatedImagesService.getGeneratedImage(resp.submissionId)),
    ).subscribe(
      response => { 
        console.log(response); 
        this.generatedArtProgress = response; 
        this.loading = false; 
      });
  }

}
