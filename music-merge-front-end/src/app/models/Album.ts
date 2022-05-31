import { AlbumsByArtistService } from "../albums-by-artist.service";

export interface Album{
    id: number;
    title: string;
}

export type PostAlbums = Omit<Album, "Id">;


