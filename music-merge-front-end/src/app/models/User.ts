export interface User{
    UserId: number,
    UserName: string;
    authority: string,
    CreatedDate: Date;    
    SpotifyGUID: number,
}
export type PostUser = Omit<User, "userId">;