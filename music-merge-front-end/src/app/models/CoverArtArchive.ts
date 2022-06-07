

export interface CoverArtArchive{
    image: string;
    largeImage: string;    
}

export type CovertArtImage = Omit<CoverArtArchive, "mbid">;