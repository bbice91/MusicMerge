﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicMerge;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using MusicMerge.Models;

namespace MusicMerge.Data
{
    public class MusicMergeContext : DbContext
    {
        private string _connectionString;

        public MusicMergeContext(DbContextOptions<MusicMergeContext> options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }

        public DbSet<GeneratedImage> generatedImages { get; set; }

        public DbSet<User> Users { get; set; }

        public async Task<User> UpsertSpotifyUser(SpotifyUser spotifyUser, string token)
        {
            User user = null;
            try
            {
                user = await Users.FirstOrDefaultAsync(user => user.UserName == spotifyUser.display_name);
            }
            catch(Exception ex)
            {
                Console.WriteLine("┗( T﹏T )┛");
            }

            
            if (user == null)
            {
                user = new User();
                user.UserName = spotifyUser.display_name;
                user.SpotifyGuid = spotifyUser.id;
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



        //public MusicMergeContext(IOptions<DBConfig> dbConfig)
        //{
        //    _connectionString = dbConfig.Value.Angular;
        //}
    }

}
            
        

        //public User GetUser(int Id)
        //{
        //    var MMUsers = Users.Find(Id);

//    return MMUsers;
//}
//public User AddUser(int Id, User users)
//{
//    User userEntity = Users.Add(users).Entity;
//    SaveChanges();
//    return userEntity;
//}
//public User UpdateUser(int Id)
//{
//    var MMUsers = Users.Find(Id);
//    if (MMUsers != null)
//    {


//        var entityUsers = Users.Update(MMUsers).Entity;
//        SaveChanges();
//        return entityUsers;
//    }
//    return null;
//}

//public IEnumerable<Album> GetAlbums(int Id)
//{
//    return Albums;
//}

//public Album GetAlbum(int Id)
//{
//    var MMAlbums = Albums.Find(Id);

//    return MMAlbums;
//}

//public Album AddAlbumOne(Album FirstAlbumInput)
//{

//    var albumEntityOne = Albums.Add(FirstAlbumInput).Entity;
//    SaveChanges();
//    return albumEntityOne;

//}

//public Album AddAlbumTwo(Album SecondAlbumInput)
//{

//    var albumEntityTwo = Albums.Add(SecondAlbumInput).Entity;
//    SaveChanges();
//    return albumEntityTwo;

//}

//public Album UpdateAlbum(Album description, Album Id)
//{
//    var MMAlbums = Albums.Find(Id);
//    if (MMAlbums != null)
//    {
//        MMAlbums.FirstAlbumInput = description.FirstAlbumInput;
//        MMAlbums.SecondAlbumInput = description.SecondAlbumInput;

//        var entityAlbums = Albums.Update(MMAlbums).Entity;
//        SaveChanges();
//        return entityAlbums;
//    }
//    return null;
//}

//public Album DeleteAlbum(int Id)
//{
//    var MMAlbum = Albums.Find(Id);

//    if (MMAlbum != null)
//    {
//        var Aentity = Albums.Remove(MMAlbum).Entity;
//        SaveChanges();
//        return Aentity;
//    }

//    return null;

//}

//public IEnumerable<GeneratedImage> GetGeneratedImages()
//{
//    return GeneratedImages;
//}

//public GeneratedImage GetGeneratedImage(int Id)
//{
//    var MMGeneratedImage = GeneratedImages.Find(Id);

//    return MMGeneratedImage;
//}

//public GeneratedImage UpdateGeneratedImage(GeneratedImage GeneratedImagePath, GeneratedImage Id)
//{
//    var MMGeneratedImage = GeneratedImages.Find(Id);
//    if (MMGeneratedImage != null)
//    {                

//        var entityGeneratedImages = GeneratedImages.Update(MMGeneratedImage).Entity;
//        SaveChanges();
//        return entityGeneratedImages;
//    }
//    return null;
//}
//public GeneratedImage AddGeneratedImage(GeneratedImage Id)
//{

//    var generatedImageEntity = GeneratedImages.Add(Id).Entity;
//    SaveChanges();
//    return generatedImageEntity;

//}

//public GeneratedImage DeleteGeneratedImage(int Id)
//{
//    var MMGeneratedImage = GeneratedImages.Find(Id);

//    if (MMGeneratedImage != null)
//    {
//        var GIentity = GeneratedImages.Remove(MMGeneratedImage).Entity;
//        SaveChanges();
//        return GIentity;
//    }
//    return null;
//}



// Updated upstream
//Album IGetAlbums.GetAlbums(int id)
//{

        /*public MusicMergeContext(IOptions<DBConfig> dbConfig)
        {
            _connectionString = dbConfig.Value.Angular;
        }*/

//        public User GetUser(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public User AddUser(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public User UpdateUser(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Album UpdateAlbum(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Album GetAlbum(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Album GetAlbums(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Album AddAlbum(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public GeneratedImage AddGeneratedImage(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public GeneratedImage GetGeneratedImage(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public GeneratedImage UpdateGeneratedImage(int id)
//        {
//>>>>>>> Stashed changes
//            throw new NotImplementedException();
//        }
    //}

