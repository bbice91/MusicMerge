export interface AlbumByArtist{
    id: string,
    name: string,
}

export type PostArtist = Omit<AlbumByArtist, "id">;