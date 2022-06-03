export interface GeneratedImages{
    generatedImageId: number;
    generatedImagePath: string;
}

export type PostGeneratedImage = Omit<GeneratedImages, "generatedImageId">;