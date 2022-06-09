

export interface CoverArtArchive{
    image: string;
    largeImage: string;
    id: string;
    name: string;
}

export type CovertArtImage = Omit<CoverArtArchive, "mbid">;