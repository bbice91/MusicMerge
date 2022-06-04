

export interface Album{
    id: string;
    name: string;
}

export type PostAlbums = Omit<Album, "Id">;


