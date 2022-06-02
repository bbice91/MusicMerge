

export interface Album{
    mbid: string;
    title: string;
}

export type PostAlbums = Omit<Album, "Id">;


