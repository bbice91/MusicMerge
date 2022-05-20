import { AlbumsService } from "../albums.service";

export interface Albums{
    albumId: number;
    firstAlbumInput: string;
    secondAlbumInput: string;
    description: string;
    //new album cover that hasnt existed before that user creates with album choice
    createdById: number;
    //FK user Id
    // createdDate: string;
    // updatedDate: string;

}

export type PostAlbums = Omit<Albums, "albumId">;


