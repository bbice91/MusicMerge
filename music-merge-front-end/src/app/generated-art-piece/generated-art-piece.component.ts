import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { filter, mergeMap, Subscription } from 'rxjs';
import { AuthLoginService } from '../auth-login.service';
import { GeneratedImagesService } from '../generated-images.service';
import { deepImageStyles } from '../stylesData';


@Component({
  selector: 'app-generated-art-piece',
  templateUrl: './generated-art-piece.component.html',
  styleUrls: ['./generated-art-piece.component.css']
})
export class GeneratedArtPieceComponent implements OnInit, OnDestroy {
  images: string[] = [];
  imagesSub!: Subscription;

  constructor(
    private generatedImagesService: GeneratedImagesService,
    private authService: AuthLoginService
  ) { }

  ngOnInit(): void {
    this.imagesSub = this.generatedImagesService
    .getImagesById(JSON.parse(localStorage.getItem("user")!).id)
    .subscribe(images => this.images = images);
  }

  ngOnDestroy(): void {
    this.imagesSub.unsubscribe();
  }
}
