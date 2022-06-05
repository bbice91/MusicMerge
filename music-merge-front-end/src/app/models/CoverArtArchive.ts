

export interface CoverArtArchive{
    mbid: string;
    coverArt: string;
    
}

export type CovertArtImage = Omit<CoverArtArchive, "mbid">;