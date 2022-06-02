//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using MusicMerge;

//namespace MusicMerge.Data
//{
//    public interface IMusicMergeContext : IGetUser, IAddUser, IUpdateUser, IUpdateAlbum, IGetAlbum, IGetAlbums, IAddAlbumOne, IAddAlbumTwo, IAddGeneratedImage, IGetGeneratedImages, IUpdateGeneratedImage, IGetGeneratedImage
//    {
//    }

//    public interface IGetUser
//    {
//        User GetUser(int id);
//    }

//    public interface IAddUser
//    {
//        User AddUser(int id);
//    }
//    public interface IUpdateUser
//    {
//        User UpdateUser(int id);
//    }
//    public interface IUpdateAlbum
//    {
//        Album UpdateAlbum(int id);
//    }

//    public interface IGetAlbum
//    {
//        Album GetAlbum(int id);
//    }

//    public interface IGetAlbums
//    {
//        Album GetAlbums(int id);
//    }
//    public interface IAddAlbumOne
//    {
//        Album AddAlbumOne(int id);
//    }

//    public interface IAddAlbumTwo
//    {
//        Album AddAlbumTwo(int id);
//    }

//    public interface IDeleteAlbum
//    {
//        Album DeleteAlbum(int Id);
//    }

//    public interface IUpdateGeneratedImage
//    {
//        GeneratedImage UpdateGeneratedImage(int id);
//    }

//    public interface IGetGeneratedImage
//    {
//        GeneratedImage GetGeneratedImage(int id);
//    }

//    public interface IGetGeneratedImages
//    {
//        GeneratedImage GetGeneratedImage(int id);
//    }
//    public interface IAddGeneratedImage
//    {
//        GeneratedImage AddGeneratedImage(int id);
//    }

//    public interface IDeleteGeneratedImage
//    {
//        GeneratedImage DeleteGeneratedImage(int Id);
//    }

//}


