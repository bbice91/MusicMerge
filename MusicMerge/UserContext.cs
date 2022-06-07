using MusicMerge.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MusicMerge
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public async Task<User> UpsertSpotifyUser(SpotifyUser spotifyUser, string token)
        {
            var user = await Users.FirstOrDefaultAsync(user => user.UserName == spotifyUser.displayName);
            if (user == null)
            {
                user = new User();
                user.UserName = spotifyUser.login;
                user.SpotifyGuid = spotifyUser.id;
                user.Authorize = Authorize.Spotify;
                user.Token = token;
                user = (await Users.AddAsync(user)).Entity;
            }
            else
            {
                user.Token = token;
                Users.Update(user);
            }

            await SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            return await Users.FindAsync(id);
        }

        public async Task<User> UpdateUserToken(int id, string token)
        {
            var user = await GetUser(id);
            user.Token = token;
            Users.Update(user);
            await SaveChangesAsync();
            return user;

        }

        internal Task UpsertSpotifyUser(User spotifyUser, string accessToken)
        {
            throw new NotImplementedException();
        }

        public bool IsLoggedIn(int id)
        {
            var user = Users.Find(id);

            return user != null && user.Token != null;
        }



    }



}
