export interface User{
    UserId: number,
    UserName: string;
    Token: string,
    CreatedDate: Date;    
    SpotifyGUID: number,
}
export type PostUser = Omit<User, "userId">;