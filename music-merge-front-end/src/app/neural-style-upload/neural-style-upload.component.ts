
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AlbumsByArtistService } from '../albums-by-artist.service';
import { PostAlbums } from '../models/Album';
import { ActivatedRoute, Router } from '@angular/router';
import { GeneratedImagesService } from '../generated-images.service';
import { GeneratedArtProgress } from '../models/GeneratedArtProgress';
import { debounceTime, delay, filter, map, Subscription, switchMap, tap } from 'rxjs';
import { DeepArtStyle } from '../models/DeepArtStyle';
import { deepImageStyles } from '../stylesData';
import { AuthLoginService } from '../auth-login.service';

@Component({
  selector: 'app-album-upload',
  templateUrl: './neural-style-upload.component.html',
  styleUrls: ['./neural-style-upload.component.css']
})
export class NeuralStyleUploadComponent implements OnInit, OnDestroy {

  albumUrlInput = new FormControl('');
  styleInput = new FormControl('');
  loading: boolean = false;
  generatedArtProgress: GeneratedArtProgress = { status: "", url: "" };
  styles: DeepArtStyle[] = deepImageStyles;
  sub!: Subscription;

  constructor(
    public generatedImagesService: GeneratedImagesService,
    private activatedRoute: ActivatedRoute,
    private authLoginService: AuthLoginService,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      const imgUrl = params['imageUrl'];
      if (imgUrl) {
        this.albumUrlInput.setValue(imgUrl);
      }
    })
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  generateArt(): void {
    this.loading = true;
    const photo_url = this.albumUrlInput.value;
    const style_id = this.styleInput.value;
    this.sub = this.generatedImagesService.generateArt(photo_url, style_id).pipe(
      delay(5000),
      map(x => ({ userId: JSON.parse(localStorage.getItem("user")!).id, submissionId: x.submissionId })),
      switchMap(ids => this.generatedImagesService.getGeneratedImage(ids.submissionId, ids.userId)),
    ).subscribe(
      response => {
        console.log(response);
        this.generatedArtProgress = response;
        this.loading = false;
      });
  }

}
