import { AlbumsByArtistService } from "../albums-by-artist.service";

export interface Album{
    mbid: string;
    title: string;
}

export type PostAlbums = Omit<Album, "Id">;


