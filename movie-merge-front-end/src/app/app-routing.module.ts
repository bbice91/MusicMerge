import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { AlbumUploadComponent } from "./album-upload/album-upload.component";
import { ContactComponent } from "./contact/contact.component";

// const routes: Routes = [
//     {path: 'home', component: HomeComponent},
//     {path: 'album-upload', component: AlbumUploadComponent},
//     {path: 'contact', component: ContactComponent}
// ];

const routes: Routes = [
    {
        path: "home",
        component: HomeComponent
    },
    {
        path:"contact",
        component: ContactComponent
    },
    {
        path: "album-upload",
        component: AlbumUploadComponent
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}