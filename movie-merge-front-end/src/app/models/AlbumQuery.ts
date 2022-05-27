export interface AlbumQuery{
    id: number,
    Gid: number,
    Name: string,
    Sort_Name: string,
}

export type PostAlbumQuery = Omit<AlbumQuery, "id, Gid">;