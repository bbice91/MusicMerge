export interface AlbumByArtist{
    mbid: string,
    artist: string,
    title: string
}

export type PostArtist = Omit<AlbumByArtist, "id">;