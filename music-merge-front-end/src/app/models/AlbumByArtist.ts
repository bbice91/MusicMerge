export interface AlbumByArtist{
    id: number,
    artist: string,
    title: string
}

export type PostArtist = Omit<AlbumByArtist, "id">;