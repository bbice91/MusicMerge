import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NeuralStyleUploadComponent } from "./neural-style-upload/neural-style-upload.component";
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpClientModule} from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AlbumListViewComponent } from "./album-list-view/album-list-view.component";
import { GeneratedArtPieceComponent } from './generated-art-piece/generated-art-piece.component';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { ArtistSelectComponent } from './artist-select/artist-select.component';

 


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NeuralStyleUploadComponent,
    NavBarComponent,
    AlbumListViewComponent,
    GeneratedArtPieceComponent,
    LoginComponent,
    ArtistSelectComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
